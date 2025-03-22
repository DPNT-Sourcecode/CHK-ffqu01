using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions.CHK;

namespace BeFaster.App.MSTests.Solutions.CHK
{
    [TestClass]
    public class CheckoutSolutionTest
    {
        [TestMethod]
        public void CheckOut() 
        {
            Assert.AreEqual(50, CheckoutSolution.ComputePrice("A"));
        }
        [TestMethod]
        public void illegalInput() 
        { 
            Assert.AreEqual(-1, CheckoutSolution.ComputePrice("AZ"));
        }
    }
}

