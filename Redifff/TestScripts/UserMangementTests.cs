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
        public void CreateAccountLinkTest()
        {
            var homepage=new RediffHomePage(driver);
             homepage.CreateAccountLinkClick();
            Assert.That(driver.Url.Contains("register"));      
        }
    }
}
