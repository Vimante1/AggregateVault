using AggregateVault.Interfaces;
using AggregateVault.src;

namespace AggregateVault
{
    public class AggregateCommands
    {
        private readonly string FolderPath;
        public IGetVault GetVault;
       
        public AggregateCommands(string folderPath)
        {
            FolderPath = folderPath;
            GetVault = new GetVault(FolderPath);
        }
    }
}