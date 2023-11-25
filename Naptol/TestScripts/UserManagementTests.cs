using Naptol.PageObject;
using Naptol.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.TestScripts
{
    [TestFixture]
    internal class UserManagementTests:CoreCodes
    {
        [Test]
        [Order(1), Category("Regression Testing")]
        public void SearchProductTest()
        {
            var homepage = new HomePage(driver);
            if (!driver.Url.Contains("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFileePath = currDir + "/TestData/InputData.xlsx";
            string sheetName = "SearchProduct";
            List<ProductData>productDataList=ExcelUtilities.ReadExcelData(excelFileePath, sheetName);
            foreach(var  productData in productDataList) 
            { 
                string productName=productData.ProductName;
                Console.WriteLine($"Product Name:{productName}");
                homepage.TypeSearchBox(productName);
            }
           
            //Assert.That(driver.Url.Contains("eyewear"));
            var selectproductlist=new SearchProductListPage(driver);
            selectproductlist.ClickFifthElement();

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);

            var buyProduct = new SearchProduct(driver);
            Thread.Sleep(1000);
            buyProduct.SizeSelect();
            Thread.Sleep(1000);
            buyProduct.ClickBuyNow();
            Thread.Sleep(1000);
            buyProduct.ClickClose();
            Thread.Sleep(1000);

        }
    }
}
