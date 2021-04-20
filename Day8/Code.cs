using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    class Code
    {
        public Code(string codeType, string codeNumber)
        {
            CodeType = codeType;
            CodeNumber = codeNumber;
        }

        public string CodeType { get; set; }
        public string CodeNumber { get; set; }
    }
}
