namespace Lab13_LindaAroniSuana.Application.DTOs;

public class ClientOrderReportDto
{
    
    public string ClientName { get; set; } = string.Empty;
    public int TotalOrders { get; set; }  // <-- Asegúrate de tener esta propiedad
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
}