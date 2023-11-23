using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.PageObject
{
    public class SearchProduct
    {
        IWebDriver driver;

        public SearchProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//a[text()='Black-2.50']")]
        public IWebElement Size { get; set; }
        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement BuyNowButton { get; set;}
        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement Close { get; set;}

        public void SizeSelect()
        {
            Size.Click();
        }
        public void ClickBuyNow()
        {
            BuyNowButton.Click();
        }
        public void ClickClose() 
        {
            Close.Click();
        }
    }
}
