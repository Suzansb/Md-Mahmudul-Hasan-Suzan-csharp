using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<object> objectList = new List<object>();

        objectList.Add(new { Name = "Mahmudul", Age = 25 });
        objectList.Add(new { Name = "Suzan", Age = 30 });

        foreach (var obj in objectList)
        {
            string name = obj.GetType().GetProperty("Name").GetValue(obj).ToString();
            int age = (int)obj.GetType().GetProperty("Age").GetValue(obj);
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }
}
