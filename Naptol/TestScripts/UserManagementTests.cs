using Naptol.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.TestScripts
{
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
            homepage.TypeSearchBox("eyewear"); ;
            Assert.That(driver.Url.Contains("eyewear"));
            var selectproductlist=new SearchProductListPage(driver);
            selectproductlist.ClickFifthElement();

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);

            var buyProduct = new SearchProduct(driver);
            buyProduct.SizeSelect();
            buyProduct.ClickBuyNow();
            buyProduct.ClickClose();
            Thread.Sleep(1000);

        }
    }
}
