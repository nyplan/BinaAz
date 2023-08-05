using BinaAz.Application.Abstractions.Storages;
using BinaAz.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Infrastructure.Services.Storages;

public class LocalStorageService : ILocalStorageService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LocalStorageService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        List<(string fileName, string path)> datas = new();
        foreach (IFormFile file in files)
        {
            string fileNewName = FileRenameAsync(file.FileName);
            await using var stream = new FileStream($"{uploadPath}/{fileNewName}", FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            datas.Add((fileNewName, path));
        }
        return datas;
    }

    private string FileRenameAsync(string name)
    {
        string fileName = Path.GetFileNameWithoutExtension(name);
        string fileExtension = Path.GetExtension(name);
        string regularName = NameOperation.CharacterRegulator(fileName);
        return $"{regularName}_{Guid.NewGuid()}{fileExtension}";
    }

    
    public async Task DeleteAsync(string path, string fileName)
        => File.Delete($"{path}\\{fileName}");
        
    
    
    public List<string> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }

    
    public bool HasFile(string path, string fileName)
        => File.Exists($"{_webHostEnvironment.WebRootPath}\\{path}\\{fileName}");

    public FileStream GetImageStream(string path, string filename)
    {
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, path, filename);
        return new FileStream(imagePath, FileMode.Open);
    }
}