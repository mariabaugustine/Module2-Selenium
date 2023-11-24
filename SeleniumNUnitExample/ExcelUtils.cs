using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    internal class ExcelUtils
    {
        public static List<GoogleSearch>ReadExcelData(string excelFilePath)
        {
            List<GoogleSearch> excelDataList= new List<GoogleSearch>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read)) 
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
                    var dataTable = result.Tables["GS"];
                    foreach(DataRow row in dataTable.Rows) 
                    {
                        GoogleSearch data = new()
                        {
                            Searchtest = row["searchtext"].ToString(),
                        };
                        excelDataList.Add(data);
                    }
                }
            }
            return excelDataList;   
        }
    }
}
