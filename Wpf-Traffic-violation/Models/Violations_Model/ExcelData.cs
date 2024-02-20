using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class ExcelData
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }

    //public List<ExcelData> ReadExcelFiles(string filePath)
    //{
    //    List<ExcelData> dataList = new List<ExcelData>();

    //    FileInfo fileInfo = new FileInfo(filePath);
    //    using (ExcelPackage package = new ExcelPackage(fileInfo))
    //    {
    //        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

    //        int rowCount = worksheet.Dimension.Rows;
    //        int colCount = worksheet.Dimension.Columns;

    //        for (int row = 2; row <= rowCount; row++) // Assuming the first row is the header
    //        {
    //            ExcelData data = new ExcelData
    //            {
    //                Column1 = worksheet.Cells[row, 1].Text,
    //                Column2 = worksheet.Cells[row, 2].Text,
    //                // Add other properties as needed
    //            };

    //            dataList.Add(data);
    //        }
    //    }

    //    return dataList;
    //}
}