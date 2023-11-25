using Naptol.PageObject;
using Naptol.Utilities;
using OpenQA.Selenium;
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
                TakeScreenShot();
            }
           
            //Assert.That(driver.Url.Contains("eyewear"));
            var selectproductlist=new SearchProductListPage(driver);
            selectproductlist.ClickFifthElement();
            TakeScreenShot();

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();

            var buyProduct = new SearchProduct(driver);
            Thread.Sleep(1000);
           
         
            buyProduct.SizeSelect();
            Thread.Sleep(1000);
            buyProduct.ClickBuyNow();
            TakeScreenShot() ;
            Thread.Sleep(1000);
            var cart = new Cart(driver);
            
            cart.ClickIncrement("2");
            TakeScreenShot();
            
            Thread.Sleep(3000);
            cart.ClickRemove();
            TakeScreenShot();
            Thread.Sleep(1000);
            try
            {
                IWebElement value = driver.FindElement(By.XPath("//*[@id=\"ShoppingCartPopup\"]/div[2]/span"));
                Assert.AreEqual(value.Text, "You have No Items in Cart !!!");
                test = extent.CreateTest("Remove item from cart - Pass");
                test.Pass("Remove item from cart success");
                Console.WriteLine("ERCP");
            }
            catch
            {
                test = extent.CreateTest(" Remove item from cart- Fail");
                test.Fail("Remove item from cart fail");
                Console.WriteLine("ERCF");
            }
       
            Thread.Sleep(1000);
            
            buyProduct.ClickClose();
            Thread.Sleep(1000);

        }
    }
}
