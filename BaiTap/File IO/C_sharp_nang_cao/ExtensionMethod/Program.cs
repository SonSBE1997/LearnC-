using System;


namespace ExtensionMethod
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number:");
            string input = Console.ReadLine();
            bool isNumber = input.IsNumber();
            Console.WriteLine(isNumber);
            bool isMinSize = input.IsMinSize(5);
            Console.WriteLine(isMinSize);
            Console.ReadLine();
        }
    }
}
