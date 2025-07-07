using Lab13_LindaAroniSuana.Application.DTOs;
using MediatR;

namespace Lab13_LindaAroniSuana.Application.Features.Reports.Queries;

public class GetProductSalesReportQuery : IRequest<List<ProductSalesReportDto>> {}


