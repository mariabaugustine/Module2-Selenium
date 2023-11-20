using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Assignment20_11_2023_Flipkart
{
    public class FlipkartTests:CoreCode
    {
        [Test]
        [Order(1)]
        public void ClosePopupTest()
        {
            IWebElement webElement = driver.FindElement(By.XPath("//*[@class='_30XB9F']"));
            webElement.Click();
            Assert.AreEqual(driver.Url, "https://www.flipkart.com/");

        }
        [Test]
        [Order(2)]
        public void SearchProduct() 
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            IWebElement searchinput = fwait.Until(x => x.FindElement(By.XPath("//input[@name='q']")));
            searchinput.SendKeys("retro");
            searchinput.SendKeys(Keys.Enter);
            Assert.That(driver.Url.Contains("retro"));

        }
        

    }
}