using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions.HLO;

namespace BeFaster.App.MSTests.Solutions.HLO
{
    [TestClass]
    public class HelloSolutionTest
    {
        [TestMethod]
        public void testHello() 
        {
            Assert.AreEqual("Hello, World!", HelloSolution.Hello("World"));
        }
        [TestMethod]
        public void testNoname()
        {
            Assert.AreEqual("Hello, !", HelloSolution.Hello(null));
        }

    }
}


