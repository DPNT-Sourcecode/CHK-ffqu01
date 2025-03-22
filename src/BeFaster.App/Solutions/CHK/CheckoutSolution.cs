using BeFaster.Runner.Exceptions;
using System.Runtime.CompilerServices;

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

            Dictionary<char, List<(int, int)>> specialOffers = new Dictionary<char, List<(int, int)>>();
            specialOffers.Add('A', [ (3, 130), (5, 200) ]);
            specialOffers.Add('B', [ (2, 45) ]);

            Dictionary<char, int> countSpecialOffers = new Dictionary<char, int>();
            countSpecialOffers.Add('A', 0);
            countSpecialOffers.Add('B', 0);

            foreach(char c in skus) {
                if (priceTable.ContainsKey(c))
                {
                    sum += priceTable[c];
                    if (specialOffers.ContainsKey(c)) 
                    {
                        countSpecialOffers[c]++;
                    }
                }
                else 
                {
                    return -1;
                }
            }
            foreach (KeyValuePair<char,int> pair in countSpecialOffers)
            {
                foreach ((int, int) listItem in specialOffers[pair.Key]) 
                {
                    //find highest deal applicable
                    if(pair.Value <= listItem.Item1) 
                    {
                        //check if deal is applicable
                        if (pair.Value >= listItem.Item1)
                        {
                            sum -= pair.Value / listItem.Item1 * listItem.Item2;
                        }
                        break;
                    }
                }
            }
            return sum;
        }

        public static int CalculateDiscount(int originialPrice, (int, int) specialOffer) 
        {

            return -1;
        }
    }
}

