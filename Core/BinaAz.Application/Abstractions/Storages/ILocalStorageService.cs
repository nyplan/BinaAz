using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Abstractions.Storages;

public interface ILocalStorageService
{
    Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
    Task DeleteAsync(string path, string fileName);
    List<string> GetFiles(string path);
    bool HasFile(string path, string fileName);
    FileStream GetImageStream(string path, string filename);
}