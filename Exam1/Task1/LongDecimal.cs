using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class LongDecimal
    {
        public string Calculate(uint numerator, uint denominator, uint length)
        {
            decimal result = (decimal)numerator / denominator;
            string conValue = result.ToString($"F{length}");
            
            return conValue;
        }
    }
}
