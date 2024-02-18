using System.IO.Compression;
using AggregateVault.src.Interfaces;

namespace AggregateVault.src
{
    internal class AddVault : IAddVault
    {
        private readonly string FolderPath;
        private readonly Random rand = new Random();

        public AddVault(string folderPath)
        {
            FolderPath = folderPath;
        }


        public async Task<string> AppendAsZip(FileStream file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            var folderName = rand.Next(100000).ToString();
            var combinedPath = FolderPath + "/" + folderName;
            using (ZipArchive archive = new(file))
            {
                await Task.Run(() => archive.ExtractToDirectory(combinedPath));
            }
            return folderName;
        }
    }
}
