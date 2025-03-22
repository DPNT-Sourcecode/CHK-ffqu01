using BeFaster.App.Solutions.SUM;

namespace BeFaster.App.MSTests
{
    [TestClass]
    public class SumSolutionTest
    {
        [TestMethod]
        public void ComputeSum()
        {
            Assert.AreEqual(2, SumSolution.Sum(1, 1));
        }
        [TestMethod]
        public void TestNegativeInput()
        {
            Assert.ThrowsException<InvalidParamException>(() => SumSolution.Sum(-1, 1));
            Assert.ThrowsException<InvalidParamException>(() => SumSolution.Sum(1, -1));
        }
        [TestMethod]
        public void TestAboveMaxInput()
        {
            Assert.ThrowsException<InvalidParamException>(() => SumSolution.Sum(101, 1));
            Assert.ThrowsException<InvalidParamException>(() => SumSolution.Sum(1, 101));
        }
    }
}
