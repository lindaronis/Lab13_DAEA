using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_LindaAroniSuana.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("client-orders/export")]
    public async Task<IActionResult> ExportClientOrdersReport()
    {
        FileResponseDto result = await _mediator.Send(new ExportClientOrdersReportQuery());
        return File(result.Content, result.ContentType, result.FileName);
    }

    [HttpGet("product-sales/export")]
    public async Task<IActionResult> ExportProductSalesReport()
    {
        FileResponseDto result = await _mediator.Send(new ExportProductSalesReportQuery());
        return File(result.Content, result.ContentType, result.FileName);
    }
}

