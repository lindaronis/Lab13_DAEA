using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Interfaces;
using Lab13_LindaAroniSuana.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13_LindaAroniSuana.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly Lab13DbContext _context;

    public ReportRepository(Lab13DbContext context)
    {
        _context = context;
    }

    public async Task<List<ClientOrderReportDto>> GetClientOrdersReportAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(g => new ClientOrderReportDto
            {
                ClientName = g.First().Client.Name,
                TotalOrders = g.Count()
            }).ToListAsync();
    }

    public async Task<List<ProductSalesReportDto>> GetProductSalesReportAsync()
    {
        return await _context.Orderdetails
            .GroupBy(od => od.ProductId)
            .Select(g => new ProductSalesReportDto
            {
                ProductName = g.First().Product.Name,
                TotalQuantitySold = g.Sum(x => x.Quantity)
            }).ToListAsync();
    }

    public async Task<IEnumerable<ClientOrderReportDto>> GetClientOrdersAsync()
    {
        var result = await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .Select(o => new ClientOrderReportDto
            {
                ClientName = o.Client.Name,
                OrderDate = o.OrderDate,
                Total = o.Orderdetails.Sum(od => od.Quantity * od.Product.Price)
            })
            .ToListAsync();

        return result;
    }
}

