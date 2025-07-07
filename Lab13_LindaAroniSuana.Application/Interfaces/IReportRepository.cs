using Lab13_LindaAroniSuana.Application.DTOs;

namespace Lab13_LindaAroniSuana.Application.Interfaces;


public interface IReportRepository
{
    Task<List<ClientOrderReportDto>> GetClientOrdersReportAsync();
    Task<List<ProductSalesReportDto>> GetProductSalesReportAsync();
    Task<IEnumerable<ClientOrderReportDto>> GetClientOrdersAsync();
}

