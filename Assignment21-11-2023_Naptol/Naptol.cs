using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Assignment21_11_2023_Naptol
{
    [TestFixture]
    public class Naptol:CoreCodes

    {
        [Test]
        [Order(0)]
        public void SerachProduct()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            IWebElement searchelement = fwait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']")));
            searchelement.SendKeys("eyewear");
            searchelement.SendKeys(Keys.Enter);
            Assert.That(driver.Url.Contains("eyewear"));
        }
        [Test]
        [Order(1)]
        public void SelectFifthProduct()
        {
            IWebElement fifthelement = driver.FindElement(By.XPath("/html/body/article/article/section/div[5]/div[1]/div[5]"));
            Actions actions = new Actions(driver);
            Action moveto = () => actions.MoveToElement(fifthelement).Click().Build().Perform();

            moveto.Invoke();

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            
            
        }
    }
}