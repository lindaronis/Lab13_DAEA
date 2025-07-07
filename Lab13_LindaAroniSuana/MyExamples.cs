using ClosedXML.Excel;

namespace Lab13_LindaAroniSuana
{
    public class MyExamples
    {
        public void FirstExample()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hoja1");

                worksheet.Cell(1, 1).Value = "Nombre";
                worksheet.Cell(1, 2).Value = "Edad";
                worksheet.Cell(2, 1).Value = "Juan";
                worksheet.Cell(2, 2).Value = 28;

                workbook.SaveAs(
                    "D:\\2025-A\\EMPRES-AVANZA\\Lab13_LindaAroniSuana\\Lab13_LindaAroniSuana\\Lab13_LindaAs.xlsx");
            }
        }

        public void SecondExample()
        {
            using (var workbook = new XLWorkbook(@"D:\2025-A\EMPRES-AVANZA\Lab13_LindaAroniSuana\Lab13_LindaAroniSuana\Lab13_LindaAs.xlsx"))
            {
                var worksheet = workbook.Worksheet(1);

                worksheet.Cell(2, 2).Value = 30;

                workbook.Save();
            }
        }

        public void ThirdExample()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");
                
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Edad";
                
                worksheet.Cell(2, 1).Value = 1;
                worksheet.Cell(2, 2).Value = "Juan";
                worksheet.Cell(2, 3).Value = 28;
                
                worksheet.Cell(3, 1).Value = 2;
                worksheet.Cell(3, 2).Value = "Maria";
                worksheet.Cell(3, 3).Value = 34;
                
                var range = worksheet.Range("A1:C3");
                range.CreateTable();
                
                workbook.SaveAs(
                    "D:\\2025-A\\EMPRES-AVANZA\\Lab13_LindaAroniSuana\\Lab13_LindaAroniSuana\\Lab13_LindaAs.xlsx");
            }
            
        }

        public void FourthExample()
        {
            using (var workbook = new XLWorkbook())
            {
                    var worksheet = workbook.Worksheets.Add(sheetName: "Estilos");

                    var headerRow = worksheet.Row(1);
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell(row: 1, column: 1).Value = "ID";
                    worksheet.Cell(row: 1, column: 2).Value = "Nombre";
                    worksheet.Cell(row: 1, column: 3).Value = "Edad";
                    worksheet.Cell(row: 2, column: 1).Value = 1;
                    worksheet.Cell(row: 2, column: 2).Value = "Juan";
                    worksheet.Cell(row: 2, column: 3).Value = 28;

                    workbook.SaveAs (file: "D:\\2025-A\\EMPRES-AVANZA\\Lab13_LindaAroniSuana\\Lab13_LindaAroniSuana\\Lab13_Linda_Estilos.xlsx");
            }
        }
    }
}














