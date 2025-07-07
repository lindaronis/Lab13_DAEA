using ClosedXML.Excel;
using Lab13_LindaAroniSuana.Application.DTOs;
using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using Lab13_LindaAroniSuana.Application.Interfaces;
using MediatR;

namespace Lab13_LindaAroniSuana.Application.Features.Reports.Handlers;

public class ExportProductSalesReportHandler : IRequestHandler<ExportProductSalesReportQuery, FileResponseDto>
{
    private readonly IReportRepository _repository;

    public ExportProductSalesReportHandler(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<FileResponseDto> Handle(ExportProductSalesReportQuery request, CancellationToken cancellationToken)
    {
        var sales = await _repository.GetProductSalesReportAsync();

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("VentasProductos");

        worksheet.Cell("A1").Value = "REPORTE DE VENTAS POR PRODUCTO";
        worksheet.Range("A1:B1").Merge().Style
            .Font.SetBold()
            .Font.SetFontSize(16)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            .Fill.SetBackgroundColor(XLColor.Coral);

        worksheet.Cell(2, 1).Value = "Producto";
        worksheet.Cell(2, 2).Value = "Cantidad Vendida";

        var headerRange = worksheet.Range("A2:B2");
        headerRange.Style.Font.SetBold();
        headerRange.Style.Fill.SetBackgroundColor(XLColor.Salmon);
        headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        int row = 3;
        foreach (var s in sales)
        {
            worksheet.Cell(row, 1).Value = s.ProductName;
            worksheet.Cell(row, 2).Value = s.TotalQuantitySold;
            row++;
        }

        for (int i = 3; i < row; i++)
        {
            if ((i - 3) % 2 == 0)
                worksheet.Row(i).Style.Fill.BackgroundColor = XLColor.White;
            else
                worksheet.Row(i).Style.Fill.BackgroundColor = XLColor.MistyRose;
        }

        worksheet.Columns().AdjustToContents();

        worksheet.SheetView.FreezeRows(2);

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return new FileResponseDto
        {
            Content = stream.ToArray(),
            FileName = $"VentasProductos_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
        };
    }
}
