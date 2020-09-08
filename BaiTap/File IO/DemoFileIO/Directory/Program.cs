using System;
using System.Text;
using System.IO;

namespace Directory
{
    class Program
    {

        public static void GetDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine("Filename : " + file.FullName);
            }

            DirectoryInfo[] directory = dir.GetDirectories();
            foreach (DirectoryInfo di in directory)
            {
                GetDirectory(di.FullName);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string path = @"D:\hoc tap\C#";
            GetDirectory(path);
            Console.Read();
        }
    }
}
