using System;
using System.IO;
using System.Text;

namespace _90SISO.Core
{
    /// <summary>
    /// Патчит готовый ISO9660-образ, добавляя El Torito boot record (BIOS).
    /// Работает для boot image размером кратно 512 байт (обычно 512/2048).
    /// </summary>
    public static class ElTorito
    {
        public class BootOptions
        {
            public string BootImagePath;     // путь к .bin (512 байт boot sector)
            public bool NoEmulation = true;  // no-emul (современный) или floppy-emul
            public ushort LoadSegment = 0x7C0;
            public byte BootIndicator = 0x88; // 0x88 = bootable
        }

        public static void Apply(string isoPath, BootOptions opts)
{
    if (!File.Exists(opts.BootImagePath))
        throw new FileNotFoundException("Boot image not found", opts.BootImagePath);

    var bootImage = File.ReadAllBytes(opts.BootImagePath);
    if (bootImage.Length % 512 != 0)
        throw new InvalidDataException("Boot image size must be multiple of 512 bytes.");

    using (var fs = new FileStream(isoPath, FileMode.Open, FileAccess.ReadWrite))
    {
        long bootImageLba = AppendBootImage(fs, bootImage);
        var (brvd, catalog) = BuildElTorito(opts, bootImageLba, (uint)(bootImage.Length / 512));

        // BRVD -> sector 17
        fs.Seek(17L * 2048, SeekOrigin.Begin);
        fs.Write(brvd, 0, 2048);

        // Boot Catalog -> sector 19
        fs.Seek(19L * 2048, SeekOrigin.Begin);
        fs.Write(catalog, 0, 2048);

        // 🟢 ГЛАВНЫЙ ФИКС: Выравниваем итоговый размер файла до 2048 байт
        long finalSize = fs.Length;
        long remainder = finalSize % 2048;
        if (remainder != 0)
        {
            long padding = 2048 - remainder;
            fs.Seek(0, SeekOrigin.End);
            fs.Write(new byte[padding], 0, (int)padding);
        }
        
        fs.Flush();
    }
}
        private static long AppendBootImage(FileStream fs, byte[] bootImage)
        {
            // выравниваем до 2048
            long pos = fs.Length;
            long pad = (2048 - (pos % 2048)) % 2048;
            if (pad > 0)
            {
                fs.Seek(0, SeekOrigin.End);
                fs.Write(new byte[pad], 0, (int)pad);
                pos += pad;
            }
            fs.Seek(pos, SeekOrigin.Begin);
            fs.Write(bootImage, 0, bootImage.Length);
            fs.Flush();
            return pos / 2048;
        }

        private static (byte[] brvd, byte[] catalog) BuildElTorito(BootOptions opts, long bootImageLba, uint sectorCount)
{
    var brvd = new byte[2048];
    brvd[0] = 0x00;
    Encoding.ASCII.GetBytes("CD001").CopyTo(brvd, 1);
    brvd[6] = 0x01;
    Encoding.ASCII.GetBytes("EL TORITO SPECIFICATION").CopyTo(brvd, 7);
    BitConverter.GetBytes((uint)19).CopyTo(brvd, 71); // LBA каталога

    var catalog = new byte[2048];
    // Validation Entry
    catalog[0] = 0x01;
    catalog[1] = 0x00;
    Encoding.ASCII.GetBytes("ISO_TOOL").CopyTo(catalog, 4);
    ushort sum = 0;
    for (int i = 0; i < 32; i += 2) sum += BitConverter.ToUInt16(catalog, i);
    BitConverter.GetBytes((ushort)(0x10000 - sum)).CopyTo(catalog, 28);
    catalog[30] = 0x55; catalog[31] = 0xAA;

    // Initial/Default Entry
    int e = 32;
    catalog[e + 0] = opts.BootIndicator;
    catalog[e + 1] = 0x00; // no emulation
    BitConverter.GetBytes(opts.LoadSegment).CopyTo(catalog, e + 2);
    BitConverter.GetBytes((ushort)sectorCount).CopyTo(catalog, e + 6);
    BitConverter.GetBytes((uint)bootImageLba).CopyTo(catalog, e + 8);

    return (brvd, catalog);
}

    }
}