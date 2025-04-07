using BeFaster.Runner.Exceptions;
using System.Runtime.CompilerServices;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        /// <summary>
        /// Contains prices for SKUs as a key pair: SKU, price.
        /// </summary>
        private static Dictionary<char, int> priceTable = new Dictionary<char, int>();
        /// <summary>
        /// Contains special offers for each SKU as a list: SKU, List(Number For Offer, Offer Price, Offer special condition).
        /// </summary>
        private static Dictionary<char, List<(int, int, char)>> specialOffers = new Dictionary<char, List<(int, int, char)>>();
        /// <summary>
        /// Used to count items in a basket that are on offer as: Item, Count.
        /// </summary>
        private static Dictionary<char, int> countSpecialOffers = new Dictionary<char, int>();
        /// <summary>
        /// Calculates the total price of all the items in the basket.
        /// </summary>
        /// <param name="skus">String containing list of items in the basket.</param>
        /// <returns>Int total price or -1 for illegal input.</returns>
        public static int ComputePrice(string? skus)
        {
            priceTable.Clear();
            specialOffers.Clear();
            countSpecialOffers.Clear();

            if(skus == null) return -1;
            int sum = 0;
            //fill price table
            priceTable.Add('A', 50);
            priceTable.Add('B', 30);
            priceTable.Add('C', 20);
            priceTable.Add('D', 15);
            priceTable.Add('E', 40);
            //fill special offers
            specialOffers.Add('E', [(2, 50, 'B')]); //2 * E - B
            specialOffers.Add('A', [ (3, 130, ' '), (5, 200, ' ') ]);
            specialOffers.Add('B', [ (2, 45, ' ') ]);
            //fill countSpecialOffers
            countSpecialOffers.Add('E', 0);
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
            sum -= applySpecialOffers(skus);
            
            return sum;
        }

        public static int CalculateDiscount(int originialPrice, (int, int, char) specialOffer) 
        {
            return originialPrice * specialOffer.Item1 - specialOffer.Item2;
        }
        //Thinking of refactoring to classes...
        public static int applySpecialOffers(string skus) 
        {
            int sum = 0;
            (int, int, char) maxDiscount = (0, 0, ' ');
            int currentCount = 0;
            int TIMEOUT = 0;
            Dictionary<char, int> excluded = new Dictionary<char, int>(); 

            foreach (KeyValuePair<char, int> pair in countSpecialOffers)
            {
                currentCount = pair.Value;
                if (excluded.ContainsKey(pair.Key)) 
                {
                    currentCount -= excluded[pair.Key];
                }
                while (currentCount > 0 && currentCount >= specialOffers[pair.Key][0].Item1 && TIMEOUT < skus.Length)
                {
                    foreach ((int, int, char) listItem in specialOffers[pair.Key])
                    {
                        if (listItem.Item3 != ' ')
                        {
                            if (!skus.Contains(listItem.Item3)) break;
                        }
                        if (currentCount >= listItem.Item1)
                        {
                            maxDiscount = listItem;
                            if (excluded.ContainsKey(listItem.Item3))
                            {
                                excluded[listItem.Item3]++;
                            }
                            else
                            {
                                excluded.TryAdd(listItem.Item3, 1);
                            }
                        }
                    }
                    currentCount -= maxDiscount.Item1; //subtract highest discount count
                    sum += CalculateDiscount(priceTable[pair.Key], maxDiscount); //add discount to sum
                    maxDiscount = (0, 0, ' ');
                    TIMEOUT++;
                }
                currentCount = 0;
            }
            return sum;
        }

    }
}
