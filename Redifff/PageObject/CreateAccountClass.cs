using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redifff.PageObject
{
    internal class CreateAccountClass
    {
        IWebDriver driver;
        public CreateAccountClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Arranage
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'name')]")]
        public IWebElement? FullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')]")]
        public IWebElement? RediffmailId { get; set; }


        [FindsBy(How =How.XPath,Using = "//input[contains(@name,'btnchk')]")]
        public IWebElement CheckAvailability { get; set; }

        [FindsBy(How =How.Id,Using = "Register")]
        public IWebElement CreateMyAccountBtn { get; set; }


        //Act
        public void FullNameType(string fullname)
        {
            FullName?.SendKeys(fullname);
        }
        public void ReddifMailType(string email)
        {
           RediffmailId?.SendKeys(email);
        }
        public void CheckAvailabilityClick()
        {
            CheckAvailability?.Click();
        }
        public void CreateMyAccountBtnClick() 
        {
            CreateMyAccountBtn.Click();
        }
        public void FullNameClear()
        {
            FullName?.Clear();
        }
        public void ReddifMailClear()
        {
            RediffmailId?.Clear();
        }
        public void CheckAvailabilityClear()
        {
            CheckAvailability?.Clear();
        }
    }
}
