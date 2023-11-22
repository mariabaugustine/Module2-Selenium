using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redifff.PageObject
{
    internal class RediffHomePage
    {
        IWebDriver driver;
        public RediffHomePage(IWebDriver driver) 
        {
          this.driver = driver;
        }
        //Arranage
        [FindsBy(How =How.LinkText,Using = "Create Account")]
        public IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How=How.LinkText,Using = "Sign in")]
        public IWebElement? SignInLink { get; set; }


        //Act
        public void CreateAccountLinkClick()
        {
            CreateAccountLink?.Click();
        }
        public void SignInLinkClick() 
        {
            SignInLink?.Click(); 
        }
    }
}
