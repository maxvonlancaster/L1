using System;
using System.Collections.Generic;
using System.Text;

namespace L1.Services
{
    public class Features
    {
        public Features()
        {
        }

        public Features(string variant)
        {
            Variant = variant;
        }

        public string Variant { get; set; }
    }
}
