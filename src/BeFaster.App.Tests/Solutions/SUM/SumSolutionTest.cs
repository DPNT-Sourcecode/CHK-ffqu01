using BeFaster.App.Solutions.SUM;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class SumSolutionTest
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        public int ComputeSum(int x, int y)
        {
            return SumSolution.Sum(x, y);
        }

        [TestCase(-1,1)]
        public void negativeParameter(int x, int y)
        {
            Assert.Throws<InvalidParamException>(SumSolution.Sum(x, y));
        }

        //I'm going to switch to using the built in unit testing library as it is what i am more familiar with :)
    }
}

