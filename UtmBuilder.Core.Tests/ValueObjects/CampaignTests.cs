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
    public class CampaignTests
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("src", "", "", true)]
        [DataRow("src", "med", "", true)]
        [DataRow("src", "med", "nme", false)]
        public void CampaignTest(string source, string medium, string name, bool expectException) 
        {
            if(expectException)
            {
                try
                {
                    new Campaing(source, medium, name);
                    Assert.Fail();
                }
                catch (InvalidCampaignException)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Campaing(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}
