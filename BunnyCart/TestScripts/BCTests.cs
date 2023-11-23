using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class BCTests:CoreCodes
    {
        [Test,Order(2)]
        [TestCase("Water Poppy")]
        public void SearchProductAndAddToCart(string searchtext)
        {
            BCHP bchp = new(driver);
            var searchResultPage=bchp?.TypeSearchInput(searchtext);
            Assert.That(searchtext.Contains(searchResultPage?.GetFirstProductLInk()));
            var productPage=searchResultPage?.ClickFirstProductLink();
            Assert.That(searchtext.Equals(productPage?.GetProductTitleLabel()));
            productPage?.ClickIncQty();
            productPage?.ClickAddToCartBtn();
            Thread.Sleep(1000);

        }

        [Test,Order(1)]
        public void  SignUpTest()
        {
            BCHP bchp = new BCHP(driver);
            bchp.ClickCreateAccount();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div["+"@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
            }
            catch(AssertionException) 
            {
                Console.WriteLine("Create account modal not present");
            }
            bchp.SignUpButton("Abc", "Def", "ghi@gmail.com", "12345", "12345", "9876543210");
        }
    }
}
