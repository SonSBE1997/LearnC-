using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DemoFileIO
{
    class DemoFileStream
    {
        public static void ReadFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            if (fs.CanRead)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer));
            }
            fs.Flush();
            fs.Close();
        }

        public static void WriteFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            if (fs.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes("Say hello");
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Flush();
            fs.Close();
        }



        static void Main(string[] args)
        {

        }
    }
}
