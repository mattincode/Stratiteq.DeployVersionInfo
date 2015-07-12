using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stratiteq.DeployVersionInfoTest
{
    [TestClass]
    public class DeployControllerTests
    {
        [TestMethod]
        public void ParseChangedDate()
        {
            var changedDate = "2015-07-09T22.09.44.5240641+02.00";

            changedDate = changedDate.Substring(0, changedDate.Length - 14);
            changedDate = changedDate.Replace('T', ' ');
            changedDate = changedDate.Replace('.', ':');

            var changedOn = DateTime.Parse(changedDate);

            Assert.AreEqual(9,changedOn.Day);
            Assert.AreEqual(22, changedOn.Hour);
            Assert.AreEqual(09, changedOn.Minute);
        }
    }
}
