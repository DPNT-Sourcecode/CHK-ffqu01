using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }

    public class InvalidParamException : Exception
    {
        public InvalidParamException() { }
    }   
}


