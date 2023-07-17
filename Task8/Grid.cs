using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Grid<TClass, TStruct>
    where TClass : class
    where TStruct : struct
    {
        public TClass P1 { get; set; }
        public TStruct P2 { get; set; }
    }
}
