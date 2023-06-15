using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Player
    {
        private string name;
        private int id;

        public string Name { get; set; }
        public int Id { get; set; }

    
        public void getPlayerInfo(string name, int id)
        {
            Console.WriteLine(name + "Id: " + id);
        }

        public int ProvideMove()
        {
            int val;
            val = 1;
            return val ;
        }

    }
}
