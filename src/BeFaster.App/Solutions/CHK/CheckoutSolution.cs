﻿using BeFaster.Runner.Exceptions;

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

            Dictionary < char, (int, int)> specialOffers = new Dictionary<char, (int, int) >();
            specialOffers.Add('A', (3, 130));
            specialOffers.Add('B', (2, 45));

            int[] countSpecialOffers = new int[specialOffers.Count];

            for (int i = 0; i < skus.Length; i++) {
                if (priceTable.ContainsKey(skus[i]))
                {
                    sum += priceTable[skus[i]];
                    if (specialOffers.ContainsKey(skus[i])) 
                    {

                    }
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






