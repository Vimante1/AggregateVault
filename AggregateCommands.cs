using AggregateVault.src;
using AggregateVault.src.Interfaces;

namespace AggregateVault
{
    public class AggregateCommands
    {
        private readonly string FolderPath;
        public IGetVault GetVault;
        public IAddVault AddVault;
       
        public AggregateCommands(string folderPath)
        {
            FolderPath = folderPath;
            GetVault = new GetVault(FolderPath);
            AddVault = new AddVault(FolderPath);
        }
    }
}