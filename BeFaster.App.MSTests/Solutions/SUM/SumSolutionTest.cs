using BeFaster.App.Solutions.SUM;

namespace BeFaster.App.MSTests.Solutions.SUM
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
        [TestMethod]
        public void TestMinInput()
        {
            Assert.AreEqual(SumSolution.SUMMIN, SumSolution.Sum(SumSolution.SUMMIN, SumSolution.SUMMIN));
        }
        [TestMethod]
        public void TestMaxINput()
        {
            Assert.AreEqual(SumSolution.SUMMAX * 2, SumSolution.Sum(SumSolution.SUMMAX, SumSolution.SUMMAX));
        }
    }
}