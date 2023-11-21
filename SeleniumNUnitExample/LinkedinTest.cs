using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class LinkedinTest:CoreCodes
    {
        [Test]
        [Author("Maria","mariabaugustine@gmail.com")]
        [Description("Check for valid login")]
        [Category("Regression testing")]
        public void Login1Test()
        {
          // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));


            //IWebElement emailInput =wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordInput= wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));


            IWebElement emailInput = wait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(dri => dri.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abc@gmail.com");
            passwordInput.SendKeys("12345");


           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [Test]
        [Author("Maria", "mariabaugustine@gmail.com")]
        [Description("Checking for invalid login")]
        [Category("Smoke testing")]
        public void Login2Test()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout=TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput =fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abc@gmail.com");
            passwordInput.SendKeys("12345");

        }
        //[Test]
        //[Author("AAA", "abc@gmail.com")]
        //[Description("Checking for invalid login")]
        //[Category("Regression testing")]
        //public void LoginTestWithInvalidCredential()
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";


        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys("abc@def.com");
        //    passwordInput.SendKeys("12345");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("hij@xyz.com");
        //    passwordInput.SendKeys("8765");
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("abc@gmail.com");
        //    passwordInput.SendKeys("09876");
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        //[Test,Author("Maria", "mariabaugustine@gmail.com")]
       
        //[Description("Checking for invalid login")]
        //[Category("Smoke testing")]
        //[TestCase("abc@def.com","12345")]
        //[TestCase("hij@xyz.com", "8765")]
        //[TestCase("abc@gmail.com", "09876")]
        //public void InvalidLoginCredentialTest(string email,string password)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";


        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys(email);
        //    emailInput.SendKeys(password);

        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //}
        [Description("Checking for invalid login")]
        [Category("Smoke testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        
        public void InvalidLoginCredentialTest(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);

            TakeScreenShot();

            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(TimeSpan.FromSeconds(5));

        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"abc@xyz.com","1234"},
                new object[] {"def@xyz.com", "5678" }
            };
        }
       
    }
}
