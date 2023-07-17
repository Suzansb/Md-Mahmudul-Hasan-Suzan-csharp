
using System;
namespace Task8;
class Program
{
    static void Main()
    {
        Grid<string, int> grid = new Grid<string, int>();

        grid.P1 = "Suzan";
        grid.P2 = 25;

        Console.WriteLine($"Property1: {grid.P1}, Property2: {grid.P2}");
    }
}
