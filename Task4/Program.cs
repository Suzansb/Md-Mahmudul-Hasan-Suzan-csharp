using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter some string: ");
        string inputS = Console.ReadLine();

        StringBuilder sb = new StringBuilder(inputS);

        for (int i = 0; i < sb.Length; i++)
        {
            if (IsVowel(sb[i]))
            {
                sb[i] = '-';
            }
        }

        string result = sb.ToString();
        Console.WriteLine("Modified string: " + result);
    }

    static bool IsVowel(char c)
    {
        char lowerChar = char.ToLower(c);
        return lowerChar == 'a' || lowerChar == 'e' || lowerChar == 'i' || lowerChar == 'o' || lowerChar == 'u';
    }
}
