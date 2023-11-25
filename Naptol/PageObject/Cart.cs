using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.PageObject
{
    internal class Cart
    {
        IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.ClassName,Using ="input_Special_2")]
        private IWebElement IncrementQuantity { get; set; }

        [FindsBy(How =How.LinkText,Using ="Remove")]
        private IWebElement remove { get; set;}
       
        public void ClickIncrement(string number)
        {
            ClickBckspace();
            IncrementQuantity.SendKeys(number);
            IncrementQuantity.SendKeys(Keys.Alt);

        }
        public void ClickRemove()
        {
            remove.Click();
        }
        public void ClickBckspace()
        {
            IncrementQuantity.SendKeys(Keys.Backspace);
        }
   }
}
