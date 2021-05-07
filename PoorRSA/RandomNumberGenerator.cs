using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public class RandomNumberGenerator
    {
        private IList<BigInteger> list;

        private Random random;

        public RandomNumberGenerator(IList<BigInteger> list)
        {
            this.list = list;
            random = new Random();
        }

        public BigInteger Random()
        {
            return list[random.Next(list.Count)];
        }
    }
}
