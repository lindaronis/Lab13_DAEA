using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using Lab13_LindaAroniSuana.Application.Interfaces;
using MediatR;

namespace Lab13_LindaAroniSuana.Application.Features.Reports.Handlers;

public class GetClientOrdersReportHandler : IRequestHandler<GetClientOrdersReportQuery, List<ClientOrderReportDto>>
{
    private readonly IReportRepository _repo;

    public GetClientOrdersReportHandler(IReportRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ClientOrderReportDto>> Handle(GetClientOrdersReportQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetClientOrdersReportAsync();
    }
}

