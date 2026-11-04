using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;

namespace _90SISO.Core
{
    public class UsbDriveInfo
    {
        public int Index { get; set; }
        public string Model { get; set; }
        public long SizeBytes { get; set; }
        public string SizeText => (SizeBytes / 1024.0 / 1024.0 / 1024.0).ToString("F2") + " GB";
        public override string ToString() => $"PhysicalDrive{Index} — {Model} ({SizeText})";
    }

    public class UsbWriter
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDisposition,
            uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        private const uint GENERIC_WRITE = 0x40000000;
        private const uint OPEN_EXISTING = 3;
        private const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
        private const uint FILE_FLAG_WRITE_THROUGH = 0x80000000;

        public event Action<long, long> Progress; // (записано, всего)

        public static List<UsbDriveInfo> GetUsbDrives()
        {
            var result = new List<UsbDriveInfo>();
            using (var searcher = new ManagementObjectSearcher(
                "SELECT Index, Model, Size FROM Win32_DiskDrive WHERE InterfaceType='USB'"))
            {
                foreach (ManagementObject disk in searcher.Get())
                {
                    result.Add(new UsbDriveInfo
                    {
                        Index = Convert.ToInt32(disk["Index"]),
                        Model = disk["Model"]?.ToString() ?? "Unknown",
                        SizeBytes = Convert.ToInt64(disk["Size"] ?? 0L)
                    });
                }
            }
            return result;
        }

        public void WriteIsoToUsb(string isoPath, int physicalDriveNumber)
        {
            var handle = CreateFile(
                @"\\.\PhysicalDrive" + physicalDriveNumber,
                GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING,
                FILE_FLAG_NO_BUFFERING | FILE_FLAG_WRITE_THROUGH, IntPtr.Zero);

            if (handle.IsInvalid)
                throw new IOException(
                    "Не удалось открыть диск. Убедитесь, что программа запущена от имени администратора " +
                    "и диск не используется другими процессами.");

            const int bufferSize = 1024 * 1024;
            var buffer = new byte[bufferSize];

            using (var disk = new FileStream(handle, FileAccess.Write))
            using (var iso = File.OpenRead(isoPath))
            {
                long total = iso.Length;
                long written = 0;
                int read;
                while ((read = iso.Read(buffer, 0, bufferSize)) > 0)
                {
                    disk.Write(buffer, 0, read);
                    written += read;
                    Progress?.Invoke(written, total);
                }
                disk.Flush();
            }
        }
    }
}