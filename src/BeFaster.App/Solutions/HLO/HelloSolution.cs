using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public static class HelloSolution
    {
        /// <summary>
        /// Says hello to a friend
        /// </summary>
        /// <param name="friendName">String containing a name.</param>
        /// <returns>
        /// Returns Hello + 'friendName'.
        /// </returns>
        public static string Hello(string? friendName)
        {
            return $"Hello, {friendName}!";
        }
    }
}
