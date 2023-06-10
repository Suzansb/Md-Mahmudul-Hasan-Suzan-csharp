using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class VIPCustomer : Customer
    {
        public string type { get; set; }

        public VIPCustomer(): this(string.Empty) { }

        public VIPCustomer(string name): base(name) { 
            _name = name;
        }

        public double takeloan(double amount)
        {
            return amount;
        }

    }
}
