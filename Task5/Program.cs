using System;

class Program
{
    static void Main()
    {
        Print("Welcome", "Exam2");
        Print("This", "is", "an", "example of", "massages in params");
        Print();
    }

    static void Print(params string[] messages)
    {
        foreach (string message in messages)
        {
            Console.WriteLine(message);
        }
    }
}
