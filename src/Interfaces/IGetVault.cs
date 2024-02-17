using System;
using System.IO;

namespace AggregateVault.Interfaces;
public interface IGetVault
{
    public Task<MemoryStream> ReturnZip(string[] id);
    public Task<List<string>> ReturnIdList();
}