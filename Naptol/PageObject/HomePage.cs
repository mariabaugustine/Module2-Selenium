using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naptol.PageObject
{
    internal class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How =How.Id,Using =("header_search_text"))]
        public IWebElement searchElement { get; set; }
         public void TypeSearchBox(string product)
         {
             searchElement.SendKeys(product);
             searchElement.SendKeys(Keys.Enter);
         }
       

    }
}

