using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.Utilities
{
    internal class ExcelUtilities
    {
        public static List<ProductData>ReadExcelData(string excelFilePath, string sheetname)
        {
            List<ProductData> productDatalist=new List<ProductData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream)) 

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if(datatable != null)
                    {
                        foreach(DataRow row in datatable.Rows) 
                        {
                            ProductData productData = new ProductData
                            {
                                ProductName = GetValueOrDefault(row,"productname")

                            };
                        productDatalist.Add(productData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }
           
            return productDatalist;
        }
        static string GetValueOrDefault(DataRow row, string columnName) 
        {
            Console.WriteLine(row+""+columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}
