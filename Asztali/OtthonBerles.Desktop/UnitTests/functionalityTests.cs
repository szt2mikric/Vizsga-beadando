using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtthonBerles.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    class functionalityTests
    {
        [TestMethod]
        public void loginTests()
        {
            Assert.IsTrue(DBHelper.ConnectToDatabase("root", "root"));
        }
    }
}
