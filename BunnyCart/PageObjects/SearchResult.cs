using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResult
    {
        IWebDriver driver;

        public SearchResult(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using ="")]
        private IWebElement? FirstProductLink { get; set; }

        public string? GetFirstProductLInk()
        {
            return FirstProductLink?.Text;
        }
        public ProductPage ClickFirstProductLink()
        {
            FirstProductLink?.Click();
            return new ProductPage(driver);
           
        }
    }
}
