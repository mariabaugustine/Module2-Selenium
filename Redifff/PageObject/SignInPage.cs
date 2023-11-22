using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redifff.PageObject
{
    internal class SignInPage
    {
        IWebDriver? driver;

        public SignInPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How =How.Id,Using =("login1"))]
        public IWebElement UserName { get; set; }

        [FindsBy(How=How.Id,Using =("password"))]
        public IWebElement Password { get; set; }

        [FindsBy(How =How.Id,Using =("remember"))]
        public IWebElement RememberMeCheckBox { get; set; }

        [FindsBy(How=How.Name,Using =("proceed"))]
        public IWebElement SignInButton { get; set; }

        public void TypeUserName(string userName) 
        { 
            UserName.SendKeys(userName);
        }
        public void TypePassword(string password)
        {
            Password.SendKeys(password);
        }
        public void CheckRememberMe() 
        {
            RememberMeCheckBox?.Click();
        }
        public void ClickSignInButton()
        {
            SignInButton?.Click();
        }

    }
}
