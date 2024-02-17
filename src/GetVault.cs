using AggregateVault.Interfaces;
using System.IO.Compression;

namespace AggregateVault.src;
internal class GetVault : IGetVault
{
    private readonly string FolderPath;
    public GetVault(string folderPath)
    {
        FolderPath = folderPath;
    }

    public async Task<MemoryStream> ReturnZip(string[] ids)
    {
        MemoryStream resultArchive = new MemoryStream();

        using (ZipArchive archive = new ZipArchive(resultArchive, ZipArchiveMode.Create, true))
        {
            foreach (string id in ids)
            {
                string folderPath = Path.Combine(FolderPath, id);
                if (Directory.Exists(folderPath))
                {
                    AddFolderToArchive(folderPath, archive, string.Empty);
                }
            }
        }

        resultArchive.Seek(0, SeekOrigin.Begin);
        return resultArchive;
    }

    private static void AddFolderToArchive(string sourceDirectoryName, ZipArchive archive, string parentDirectoryName)
    {
        foreach (string directoryPath in Directory.GetDirectories(sourceDirectoryName))
        {
            string directoryName = Path.GetFileName(directoryPath);
            string relativePath = Path.Combine(parentDirectoryName, directoryName);
            AddFolderToArchive(directoryPath, archive, relativePath);
        }

        foreach (string filePath in Directory.GetFiles(sourceDirectoryName))
        {
            string relativePath = Path.Combine(parentDirectoryName, Path.GetFileName(filePath));
            archive.CreateEntryFromFile(filePath, relativePath);
        }
    }


    public async Task<List<string>> ReturnIdList()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(FolderPath);
        List<string> result = directoryInfo.GetDirectories().Select(directory => directory.Name).ToList();
        return result;
    }
}