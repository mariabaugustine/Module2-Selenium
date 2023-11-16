using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class GHPTests:CoreCodes
    {
        [Test]
        public void TitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
    }
}
