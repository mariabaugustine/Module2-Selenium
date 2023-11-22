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
        }

        [Test]
        [Order(3),Category("Regression Test")]
        public void CreateAccountTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.CreateAccountLinkClick();
            Assert.That(driver.Url.Contains("register"));
        }
    }
}
