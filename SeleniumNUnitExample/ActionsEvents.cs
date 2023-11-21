using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    internal class ActionsEvents:CoreCodes
    {
        [Test]
        public void HomelinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            Actions actions = new Actions(driver);
            Action mouseOverHomeLink=()=>actions.MoveToElement(homelink).Build().Perform();
            Console.WriteLine("Before colour:"+tdhomelink.GetCssValue("background-color"));
            mouseOverHomeLink.Invoke();
            Console.WriteLine("After colour:" + tdhomelink.GetCssValue("background-color"));

        }
        [Test]
        public void MultipleActionTests()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";

            IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
            Actions actions= new Actions(driver);
            Action uppercaseInput = () => actions.KeyDown(Keys.Shift).
            SendKeys(emailInput,"abc@gmail.com").
            KeyUp(Keys.Shift).
            Build().
            Perform();

            uppercaseInput.Invoke();
            Console.WriteLine("Text is:"+emailInput.GetAttribute("value"));
            Thread.Sleep(5000);


        }
    }
}
