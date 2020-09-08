using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExampleStreamReadAndWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            //Console.OutputEncoding = Encoding.UTF8;

            //List<string> li = new List<string>();
            //List<string> li1 = new List<string>();
            string[] li = new string[5000];
            string[] li1 = new string[5000];
            using (StreamReader streamReader = new StreamReader(@"C:\laragon\www\create-data\file.txt", Encoding.UTF8))
            {
                string data = string.Empty;
                int i = 0;
                while ((data = streamReader.ReadLine()) != null)
                {
                    li[++i] = data;
                }
            }


            using (StreamReader streamReader = new StreamReader(@"C:\laragon\www\create-data\file1.txt", Encoding.UTF8))
            {
                string data = string.Empty;
                int i = 0;
                while ((data = streamReader.ReadLine()) != null)
                {
                    li1[++i] = data;
                }
            }
            ////List<int> li = new List<int>();
            ////Random random = new Random();
            ////for (int i = 1; i <= 300; i++)
            ////{
            ////    int a = random.Next(10000000, 99999999);
            ////    li.Add(a);
            ////}

            StreamWriter streamWriter = new StreamWriter(@"C:\laragon\www\create-data\file2.txt", false, Encoding.UTF8);
            ////foreach (string item in li)
            ////{
            ////        streamWriter.WriteLine("DTQT");
            ////}
            //Random ran = new Random();
            for (int i = 1; i <= 397; i++)
            {
                string[] r = li[i].Split('#');
                streamWriter.WriteLine(r[0] + li1[i] + r[1]);
            }
            streamWriter.Flush();
            streamWriter.Close();

            #endregion

            //byte[] arr = new byte[5000];
            //arr = Encoding.ASCII.GetBytes("abcd1fasdfsdfsf");
            //byte[] arr1 = new byte[5000];
            //arr.CopyTo(arr1, 1);
            //Console.WriteLine(arr.Length);
        }
    }
}
