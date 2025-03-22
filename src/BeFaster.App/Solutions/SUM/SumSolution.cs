using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        private const int SUMMAX = 100;
        private const int SUMMIN = 0;
        public static int Sum(int x, int y)
        {
            if (x <= 0 || y <= 0 || x > 100 || y > 100) 
            {
                throw new InvalidParamException("Inputs must be a positive integer between 0-100");
            }
            return x + y;
        }
    }

    public class InvalidParamException : Exception
    {
        public InvalidParamException() { }

        public InvalidParamException(string message) : base(message) { }
    }   
}

