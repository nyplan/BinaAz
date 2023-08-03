using BinaAz.Infrastructure.Operations;

namespace BinaAz.Infrastructure.Services;

public class FileService
{
    private static string FileRename(string path, string fileName)
    {
        string extension = Path.GetExtension(fileName);
        string oldName = Path.GetFileNameWithoutExtension(fileName);
        string regulatedFileName = NameOperation.CharacterRegulator(oldName);

        var files = Directory.GetFiles(path, regulatedFileName + "*");

        if (files.Length == 0) return regulatedFileName + "-1" + extension;

        int[] fileNumbers = new int[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            var lastHyphenIndex = files[i].LastIndexOf("-");
            fileNumbers[i] = int.Parse(files[i].Substring(lastHyphenIndex + 1, files[i].Length - extension.Length - lastHyphenIndex - 1));
        }

        var biggestNumber = fileNumbers.Max();
        biggestNumber++;
        return regulatedFileName + "-" + biggestNumber + extension;
    }
}