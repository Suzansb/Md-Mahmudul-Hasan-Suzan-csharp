using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Tuple<string, int>> tupleList = new List<Tuple<string, int>>();

        tupleList.Add(new Tuple<string, int>("Mahmudul", 25));
        tupleList.Add(new Tuple<string, int>("Suzan", 30));

        foreach (var t in tupleList)
        {
            Console.WriteLine($"Name: {t.Item1}, Age: {t.Item2}");
        }
    }
}
