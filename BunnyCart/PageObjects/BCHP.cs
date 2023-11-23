using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BCHP
    {
        IWebDriver? driver;

        public BCHP(IWebDriver? driver)
        {
            this.driver = driver?? throw new ArgumentException(nameof (driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id,Using = "search")]
        private IWebElement SearchInput { get; set; }

        [FindsBy(How =How.XPath,Using = "//a[text()='Create an Account']")]

        private IWebElement? CreateAnAccountLink { get; set; }

        [FindsBy(How =How.Id,Using = "firstname")]
       
        private IWebElement? FirstNameInput {  get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput {  get; set; }
        [FindsBy(How =How.Id,Using = "popup-email_address")]
        private IWebElement? EmailField { get; set; }
        [FindsBy(How=How.Id,Using = "password")]
        private IWebElement? PasswordField { get; set;}

        [FindsBy(How=How.Id,Using= "password-confirmation")]
        private IWebElement ConfirmPasswordElement { get; set; }

        [FindsBy(How =How.Id,Using = "mobilenumber")]
        private IWebElement MobileNumber {  get; set; }

        [FindsBy(How =How.XPath,Using = "//button[@title='Create an Account']")]
        private IWebElement SubmitButton {  get; set; }
        public void ClickCreateAccount()
        {
            CreateAnAccountLink.Click();
        }


        public void SignUpButton(string firstname,string lastname,string email,string password,string confirmpassword,string mobilenumber)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                        By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            EmailField?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordField?.SendKeys(password);
            ConfirmPasswordElement?.SendKeys(confirmpassword);


            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumber?.SendKeys(mobilenumber);
            Thread.Sleep(1000);

            SubmitButton?.Click();


        }
        
        public SearchResult TypeSearchInput(string searchtext)
        {
            //if(SearchInput == null)
            //{
            //    throw new NoSuchElementException
            //}
            SearchInput.SendKeys(searchtext);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResult(driver); 
        }


       


    }
}
