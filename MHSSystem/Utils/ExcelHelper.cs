using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MHSSystem.Utils
{
    public class ExcelHelper
    {
        private static DataTable ExcelToDataTableFormPath(string filePath, bool hasTitle, int worksheetIndex)
        {
            DataTable dt = new DataTable();

            using (ExcelPackage package = new ExcelPackage(new FileStream(filePath, FileMode.Open)))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets[worksheetIndex];

                int startRow = hasTitle ? sheet.Dimension.Start.Row + 1 : sheet.Dimension.Start.Row;

                // generate data columns
                for (int j = sheet.Dimension.Start.Column, k = sheet.Dimension.End.Column; j <= k; j++)
                {
                    for (int m = startRow, n = sheet.Dimension.End.Row; m <= n; m++)
                    {
                        string colName = hasTitle ? sheet.Cells[startRow - 1, j].Value.ToString() : ("column" + j).ToString();
                        while (dt.Columns.Contains(colName))
                        {
                            colName = colName + "_1";//重复行名称会报错
                        }
                        dt.Columns.Add(colName);
                    }
                }

                // add values
                for (int j = sheet.Dimension.Start.Column, k = sheet.Dimension.End.Column; j <= k; j++)
                {
                    for (int m = startRow, n = sheet.Dimension.End.Row; m <= n; m++)
                    {
                        string str = sheet.Cells[m, j].Value.ToString();
                        if (!string.IsNullOrEmpty(str))
                        {
                            // add to data table
                            DataRow dr = dt.NewRow();
                            dr[j] = str;
                        }
                    }
                }

            }





            int iRowCount = sheet.Rows.Length;
            int iColCount = sheet.Columns.Length;
            var dt = new DataTable();
            //生成列头
            for (var i = 0; i < iColCount; i++)
            {
                var name = "column" + i;
                if (hasTitle)
                {
                    var txt = sheet.Range[1, i + 1].Text;
                    if (!string.IsNullOrEmpty(txt)) name = txt;
                }
                while (dt.Columns.Contains(name)) name = name + "_1";//重复行名称会报错。
                dt.Columns.Add(new DataColumn(name));
            }
            //生成行数据
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            var rowIdx = hasTitle ? 2 : 1;
            for (var iRow = rowIdx; iRow <= iRowCount; iRow++)
            {
                var dr = dt.NewRow();
                for (var iCol = 1; iCol <= iColCount; iCol++)
                {
                    dr[iCol - 1] = sheet.Range[iRow, iCol].Value2;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
