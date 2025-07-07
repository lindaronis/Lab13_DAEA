using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using Lab13_LindaAroniSuana.Application.Interfaces;
using MediatR;

namespace Lab13_LindaAroniSuana.Application.Features.Reports.Handlers;

public class GetProductSalesReportHandler : IRequestHandler<GetProductSalesReportQuery, List<ProductSalesReportDto>>
{
    private readonly IReportRepository _repo;

    public GetProductSalesReportHandler(IReportRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ProductSalesReportDto>> Handle(GetProductSalesReportQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetProductSalesReportAsync();
    }
}

