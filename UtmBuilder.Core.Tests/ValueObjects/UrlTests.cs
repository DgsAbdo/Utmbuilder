using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utmbuilder.Core.ValueObjects;
using Utmbuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void SouldReturnExceptionWhenUrlInvalid()
        {
            new Url("Teste");
        }

        [TestMethod]
        public void SouldReturnExceptionWhenUrlIsValid()
        {
            new Url("https://balta.io");
            Assert.IsTrue(true);
        }
    }
}
