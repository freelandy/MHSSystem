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
        public static DataTable ExcelToDataTableFormPath(string filePath, bool hasTitle, int worksheetIndex)
        {
            DataTable dt = new DataTable();

            using (ExcelPackage package = new ExcelPackage(new FileStream(filePath, FileMode.Open)))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets[worksheetIndex];

                int startRow = hasTitle ? sheet.Dimension.Start.Row + 1 : sheet.Dimension.Start.Row;

                // generate data columns
                for (int j = sheet.Dimension.Start.Column; j <= sheet.Dimension.End.Column; j++)
                {
                    string colName = hasTitle ? sheet.Cells[startRow - 1, j].Value.ToString() : ("column" + j).ToString();
                    while (dt.Columns.Contains(colName))
                    {
                        colName = colName + "_1";//重复行名称会报错
                    }
                    dt.Columns.Add(colName);
                }

                // add values
                for(int i = startRow; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = sheet.Dimension.Start.Column; j <= sheet.Dimension.End.Column; j++)
                    {
                        string str = sheet.Cells[i, j].Value.ToString();
                        if (!string.IsNullOrEmpty(str))
                        {
                            // add to data table
                            dr[j - 1] = str;
                        }
                    }

                    dt.Rows.Add(dr);
                }

            }

            return dt;
        }
    }
}
