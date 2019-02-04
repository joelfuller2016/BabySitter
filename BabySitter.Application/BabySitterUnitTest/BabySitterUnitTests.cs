using BabySitter.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterUnitTest
{
    [TestClass]
    public class BabySitterUnitTests
    {

        [TestMethod]
        [DataRow("a")]
        [DataRow("b")]
        [DataRow("c")]
        [DataRow("A")]
        [DataRow("B")]
        [DataRow("C")]
        public void VerifyFamily(string family)
        {
            Assert.IsTrue(Methods.Verifyfamily(family));
        }

        [TestMethod]
        [DataRow("1/1/2019 5pm")]
        [DataRow("1/1/2019 4am")]
        public void VerifyStartTime(string startTime)
        {
            Assert.IsTrue(Methods.VerifyStartTime(startTime));
        }

        [TestMethod]
        [DataRow("1/1/2019 5pm","1/2/2019 2am")]
        [DataRow("1/1/2019 3am", "1/1/2019 4am")]
        public void VerifyEndTime(string startTime, string endTime)
        {
            Assert.IsTrue(Methods.VerifyEndTime(startTime, endTime));

        }

        [TestMethod]
        [DataRow("1/1/2019 5pm", "1/2/2019 4am", "A", 190)]
        public void VerifyTotalPayFamilyA(string startTime, string endTime, string family,int totalPay)
        {
            Assert.IsTrue(Methods.TotalPay(startTime,  endTime, family) == totalPay);

        }

        [TestMethod]
        [DataRow("1/1/2019 5pm", "1/2/2019 4am", "B", 140)]
        public void VerifyTotalPayFamilyB(string startTime, string endTime, string family, int totalPay)
        {
            Assert.IsTrue(Methods.TotalPay(startTime, endTime, family) == totalPay);

        }
        [TestMethod]
        [DataRow("1/1/2019 5pm", "1/2/2019 4am", "C", 189)]
        public void VerifyTotalPayFamilyC(string startTime, string endTime, string family, int totalPay)
        {
            Assert.IsTrue(Methods.TotalPay(startTime, endTime, family) == totalPay);

        }

    }
}
