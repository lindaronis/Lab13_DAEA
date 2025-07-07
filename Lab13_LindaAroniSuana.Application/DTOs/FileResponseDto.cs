namespace Lab13_LindaAroniSuana.Application.DTOs;

public class FileResponseDto
{
    public byte[] Content { get; set; } = default!;
    public string ContentType { get; set; } = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    public string FileName { get; set; } = "reporte.xlsx";
}

