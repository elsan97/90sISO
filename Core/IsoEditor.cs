using System;
using System.IO;

namespace _90SISO.Core
{
    public class IsoEditor
    {
        public event Action<string> Progress;

        /// <summary>Распаковать ISO во временную папку, вернуть путь.</summary>
        public string UnpackToTemp(string isoPath)
        {
            var temp = Path.Combine(Path.GetTempPath(), "_90SISO_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(temp);
            Progress?.Invoke("Распаковка во временную папку...");
            new IsoExtractor().Extract(isoPath, temp);
            return temp;
        }

        /// <summary>Пересобрать ISO из папки (с сохранением boot, если нужно).</summary>
        public void Repack(string sourceFolder, string outputIso, IsoBuildOptions opts)
        {
            Progress?.Invoke("Пересборка ISO...");
            new IsoBuilder().CreateIso(sourceFolder, outputIso, opts);
        }
    }
}