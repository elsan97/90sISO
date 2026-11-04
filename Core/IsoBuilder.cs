using DiscUtils.Iso9660;
using System;
using System.IO;

namespace _90SISO.Core
{
    public class IsoBuildOptions
    {
        public string VolumeLabel = "ISO_TOOL";
        public bool UseJoliet = true;
        public bool Bootable = false;
        public string BootImagePath;
        public ushort LoadSegment = 0x7C0;
    }

    public class IsoBuilder
    {
        public event Action<string> Progress;

        public void CreateIso(string sourceFolder, string outputIso, IsoBuildOptions opts = null)
        {
            opts = opts ?? new IsoBuildOptions();

            var builder = new CDBuilder
            {
                UseJoliet = opts.UseJoliet,
                VolumeIdentifier = opts.VolumeLabel
            };

            AddDirectory(builder, sourceFolder, "");

            Progress?.Invoke("Запись ISO...");
            using (var fs = File.Create(outputIso))
                builder.Build(fs);

            if (opts.Bootable && !string.IsNullOrEmpty(opts.BootImagePath))
            {
                Progress?.Invoke("Добавление El Torito boot record...");
                ElTorito.Apply(outputIso, new ElTorito.BootOptions
                {
                    BootImagePath = opts.BootImagePath,
                    LoadSegment = opts.LoadSegment
                });
            }

            Progress?.Invoke("Готово.");
        }

        private void AddDirectory(CDBuilder builder, string sourceDir, string isoPath)
        {
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var name = Path.GetFileName(file);
                var target = string.IsNullOrEmpty(isoPath) ? name : isoPath + "\\" + name;
                Progress?.Invoke("Добавление: " + target);
                builder.AddFile(target, File.ReadAllBytes(file));
            }
            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                var name = Path.GetFileName(dir);
                var target = string.IsNullOrEmpty(isoPath) ? name : isoPath + "\\" + name;
                AddDirectory(builder, dir, target);
            }
        }
    }
}