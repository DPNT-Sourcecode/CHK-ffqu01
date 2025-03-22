using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public const int SUMMAX = 100;
        public const int SUMMIN = 0;
        public static int Sum(int x, int y)
        {
            if (x < SUMMIN || y < SUMMIN || x > SUMMAX || y > SUMMAX) 
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


