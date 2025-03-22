using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        /// <summary>
        /// Calculates the total price of all the items in the basket.
        /// </summary>
        /// <param name="skus">String containing list of items in the basket.</param>
        /// <returns>Int total price or -1 for illegal input.</returns>
        public static int ComputePrice(string? skus)
        {
            int sum = 0;
            Dictionary<char, int> priceTable = new Dictionary<char, int>();
            priceTable.Add('A', 50);
            priceTable.Add('B', 30);
            priceTable.Add('C', 20);
            priceTable.Add('D', 15);

            Dictionary<string, int> specialOffers = new Dictionary<string, int>();
            specialOffers.Add("AAA", 130);
            specialOffers.Add("BB", 45);

            char[] charSkus = skus.ToArray();
            Array.Sort(charSkus); //What should i do about case of skus

            for (int i = 0; i < charSkus.Length; i++) {
                if (priceTable.ContainsKey(charSkus[i]))
                {
                    sum += priceTable[charSkus[i]];
                }
                else 
                {
                    return -1;
                }
            }

            return sum;
        }
    }
}




