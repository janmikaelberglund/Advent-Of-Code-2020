using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    class Input
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Wildcard { get; set; }
        public string Password { get; set; }

        public Input(int minValue, int maxValue, string wildcard, string password)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Wildcard = wildcard;
            Password = password;
        }
    }
}
