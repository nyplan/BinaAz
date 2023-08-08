namespace BinaAz.Application.DTOs.Image;

public record ImageToListDto
{
    public string FileName { get; set; } = null!;
    public string Path { get; set; } = null!;
}