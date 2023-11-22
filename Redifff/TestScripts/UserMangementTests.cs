using Redifff.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redifff.TestScripts
{
    internal class UserMangementTests:CoreCodes
    {
        /*
        [Test]
        [Order(1),Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            var homepage=new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
             homepage.CreateAccountLinkClick();
            Assert.That(driver.Url.Contains("register"));      
        }
        [Test]
        [Order(2),Category("Smoke Test")]
        public void SignInLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SignInLinkClick();
            Assert.That(driver.Url.Contains("login"));
        }*/

        //[Test]
        //[Order(1),Category("Regression Test")]
        //public void CreateAccountTest()
        //{
        //    var homepage = new RediffHomePage(driver);
        //   if(!driver.Url.Contains("https://www.rediff.com"))
        //    {
        //        driver.Navigate().GoToUrl("https://www.rediff.com");

        //    }
        //   var createaccountpage=homepage.CreateAccountClick();
        //    createaccountpage.FullNameType("abc");
        //    createaccountpage.ReddifMailType("abc");
        //    createaccountpage.CheckAvailability.Click();
        //    Thread.Sleep(100);
        //    createaccountpage.CreateMyAccountBtnClick();

        //}
        [Test]
        [Order(1),Category("Regression Testing")]
        public void SignInTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Contains("https://www.rediff.com"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com");
            }
            var signInPage = homepage.SignInClick();
            signInPage.TypeUserName("abc");
            signInPage.TypePassword("QAZX");
            signInPage.CheckRememberMe();
            Assert.False(signInPage?.RememberMeCheckBox.Selected);
            Thread.Sleep(1000);
            signInPage.ClickSignInButton();
        }
    }
}
