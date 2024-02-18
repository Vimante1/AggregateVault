using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateVault.src.Interfaces
{
    public interface IAddVault
    {
        public Task<string> AppendAsZip(FileStream file);
    }
}
