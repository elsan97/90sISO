using DiscUtils.Iso9660;
using System;
using System.IO;

namespace _90SISO.Core
{
    public class IsoExtractor
    {
        public event Action<string> Progress;

        public void Extract(string isoPath, string targetFolder)
        {
            using (var stream = File.OpenRead(isoPath))
            using (var reader = new CDReader(stream, true))
            {
                ExtractDirectory(reader, @"\", targetFolder);
            }
            Progress?.Invoke("Готово.");
        }

        private void ExtractDirectory(CDReader reader, string isoDir, string localDir)
        {
            Directory.CreateDirectory(localDir);

            foreach (var file in reader.GetFiles(isoDir))
            {
                var name = Path.GetFileName(file);
                var localPath = Path.Combine(localDir, name);
                Progress?.Invoke("Извлечение: " + name);
                using (var src = reader.OpenFile(file, FileMode.Open, FileAccess.Read))
                using (var dst = File.Create(localPath))
                {
                    src.CopyTo(dst);
                }
            }

            foreach (var dir in reader.GetDirectories(isoDir))
            {
                var name = Path.GetFileName(dir);
                ExtractDirectory(reader, dir, Path.Combine(localDir, name));
            }
        }
    }
}