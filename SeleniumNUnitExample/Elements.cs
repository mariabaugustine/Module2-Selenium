using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class Elements:CoreCodes
    {
        [Ignore("error")]
        [Test]
        public void TestCheckBox()
        {
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]/div/div[3]"));
            element.Click();
            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            cbmenu.Click();
            List<IWebElement>exapandclose=driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach(var item in  exapandclose)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);



        }
        [Test]
        public void TestFormElements()
        {
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("Maria");
            Thread.Sleep(1000);


            IWebElement lastNamefield = driver.FindElement(By.Id("lastName"));
            lastNamefield.SendKeys("Augustine");
            Thread.Sleep(1000);

            IWebElement emailField=driver.FindElement(By.Id("userEmail"));
            emailField.SendKeys("mariabaugustine@gmail.com");
            Thread.Sleep(1000);

            IWebElement genderfield = driver.FindElement(By.XPath("//input[@id='gender-radio-2'] //following::label"));
            genderfield.Click();
            Thread.Sleep(1000);

            IWebElement mobilefield = driver.FindElement(By.Id("userNumber"));
            mobilefield.SendKeys("9496739548");
            Thread.Sleep(1000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(1000);
            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(0);
            Thread.Sleep(1000);
            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement dobday = driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]/div[2]/div[2]/div/div/div[2]/div[2]/div[2]/div[1]"));
            dobday.Click();
            Thread.Sleep(1000);
            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            subjectsField.SendKeys("Chemistry");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            IWebElement hobbiesCheckField = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesCheckField.Click();
            Thread.Sleep(1000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Pictures\\Saved Pictures\\flower.jpeg");
            Thread.Sleep(1000);
            IWebElement currentAddress = driver.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys("abcd");
            Thread.Sleep(1000);


        }
       // [Ignore("incomplete")]
        [Test]
        public void WindowHandling()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent windows handle ->"+parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(int i=0;i<3;i++) 
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            List<string>lstWindow=driver.WindowHandles.ToList();
            foreach(var handle in lstWindow) 
            {
                Console.WriteLine("switching to window ->"+handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("Navigatiing to google");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is"+simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("confirmButton"));
            
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            element.Click();
            Thread.Sleep(1000);
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is" +confirmationAlert.Text);
            //confirmationAlert.Accept();
            confirmationAlert.Dismiss();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("promtButton"));
            
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            element.Click();
            Thread.Sleep(1000);
            IAlert promtAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is" +promtAlert.Text);
            promtAlert.SendKeys("Accepting the alert");
            Thread.Sleep(1000);
           promtAlert.Accept();
        }

    }
}
