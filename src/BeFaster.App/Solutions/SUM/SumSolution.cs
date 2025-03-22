using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public static int Sum(int x, int y)
        {
            if (x <= 0 || y <= 0) 
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
