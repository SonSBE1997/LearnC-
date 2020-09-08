using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DemoFileIO
{
    class Program
    {

        public static void ReadFile(string fileName)
        {
            Console.WriteLine(File.ReadAllText(fileName)); ;
        }

        public static void WriteFile(string fileName)
        {
            File.WriteAllText(fileName, "Hello world");
        }

        //static void Main(string[] args)
        //{
        //    string fileName = @"E:\test.txt";

        //    WriteFile(fileName);
        //    ReadFile(fileName);

        //    Console.Read();
        //}
    }
}
