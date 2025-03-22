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
        /// Contains special offers for each SKU as a list: SKU, List(Number For Offer, Offer Price).
        /// </summary>
        private static Dictionary<char, List<(int, int)>> specialOffers = new Dictionary<char, List<(int, int)>>();
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
            if(skus == null) return -1;
            int sum = 0;
            //fill price table
            priceTable.Add('A', 50);
            priceTable.Add('B', 30);
            priceTable.Add('C', 20);
            priceTable.Add('D', 15);
            priceTable.Add('E', 40);
            //fill special offers
            specialOffers.Add('A', [ (3, 130), (5, 200) ]);
            specialOffers.Add('B', [ (2, 45) ]);
            specialOffers.Add('E', [ (2, 50) ]); //2 * E - B
            //fill countSpecialOffers
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
            Console.WriteLine(sum);
            sum -= applySpecialOffers();
            
            return sum;
        }

        public static int CalculateDiscount(int originialPrice, (int, int) specialOffer) 
        {
            return originialPrice * specialOffer.Item1 - specialOffer.Item2;
        }
        //Thinking of refactoring to classes...
        public static int applySpecialOffers() 
        {
            int sum = 0;
            int maxDiscount = 0;
            foreach (KeyValuePair<char, int> pair in countSpecialOffers)
            {
                foreach ((int, int) listItem in specialOffers[pair.Key])
                {
                    //check if deal is applicable
                    if (pair.Value >= listItem.Item1)
                    {
                        Console.WriteLine($"priceTable: {priceTable[pair.Key]}, listItem: {listItem.Item1}, {listItem.Item2}");
                        maxDiscount = CalculateDiscount(priceTable[pair.Key], listItem);
                    }
                }
                sum += maxDiscount;
                maxDiscount = 0;
            }
            Console.WriteLine(sum);
            return sum;
        }
    }
}






