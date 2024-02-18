using System;
using System.IO;

namespace AggregateVault.src.Interfaces;
public interface IGetVault
{
    public Task<MemoryStream> ReturnZip(string[] id);
    public List<string> ReturnIdList();
}