using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public static class HelloSolution
    {
        /// <summary>
        /// Says hello to the world
        /// </summary>
        /// <param name="friendName"></param>
        /// <returns>
        /// Returns Hello + 'friendName'
        /// </returns>
        public static string Hello(string? friendName)
        {
            return "Hello, World!";
            //return $"Hello {friendName}";
        }
    }
}





