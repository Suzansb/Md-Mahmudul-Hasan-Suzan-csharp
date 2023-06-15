using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ChessBoard
    {
        public void Start() {
            Player player = new Player();
            Console.WriteLine("Setting the Player Info");
            player.Name = "Suzan";
            player.Id = 1;
            player.getPlayerInfo(player.Name, player.Id);
            Console.WriteLine("Please provide your first move");
           player.ProvideMove();

        }


    }
}
