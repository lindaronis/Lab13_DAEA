using ClosedXML.Excel;
using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using Lab13_LindaAroniSuana.Application.Interfaces;
using MediatR;

namespace Lab13_LindaAroniSuana.Application.Features.Reports.Handlers;

public class ExportClientOrdersReportHandler : IRequestHandler<ExportClientOrdersReportQuery, FileResponseDto>
{
    private readonly IReportRepository _repository;

    public ExportClientOrdersReportHandler(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<FileResponseDto> Handle(ExportClientOrdersReportQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetClientOrdersAsync();

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Pedidos");

        worksheet.Cell("A1").Value = "REPORTE DE PEDIDOS POR CLIENTE";
        worksheet.Range("A1:C1").Merge().Style
            .Font.SetBold()
            .Font.SetFontSize(16)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            .Fill.SetBackgroundColor(XLColor.LightBlue);

        worksheet.Cell(2, 1).Value = "Cliente";
        worksheet.Cell(2, 2).Value = "Fecha";
        worksheet.Cell(2, 3).Value = "Total";

        var headerRange = worksheet.Range("A2:C2");
        headerRange.Style.Font.SetBold();
        headerRange.Style.Fill.SetBackgroundColor(XLColor.LightSteelBlue);
        headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        int row = 3;
        foreach (var o in orders)
        {
            worksheet.Cell(row, 1).Value = o.ClientName;
            worksheet.Cell(row, 2).Value = o.OrderDate.ToString("yyyy-MM-dd");
            worksheet.Cell(row, 3).Value = o.Total;
            worksheet.Cell(row, 3).Style.NumberFormat.Format = "S/ #,##0.00"; // Formato moneda
            row++;
        }

        for (int i = 3; i < row; i++)
        {
            if ((i - 3) % 2 == 0)
                worksheet.Row(i).Style.Fill.BackgroundColor = XLColor.White;
            else
                worksheet.Row(i).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
        }

        worksheet.Columns().AdjustToContents();

        worksheet.SheetView.FreezeRows(2);

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return new FileResponseDto
        {
            Content = stream.ToArray(),
            FileName = $"PedidosClientes_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
        };
    }
}

