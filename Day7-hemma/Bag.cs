using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_hemma
{
    class Bag
    {
        public Bag(int numberOfBags, string bagType)
        {
            NumberOfBags = numberOfBags;
            BagType = bagType;
        }

        public int NumberOfBags { get; set; }
        public string BagType { get; set; }
    }
}
