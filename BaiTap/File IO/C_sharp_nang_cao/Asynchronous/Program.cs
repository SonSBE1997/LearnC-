using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Manipulate
    {
        public async Task<int> AccessTheWebAsync()
        {
            HttpClient httpClient = new HttpClient();
            Task<string> getStringTask = httpClient.GetStringAsync("http://msdn.microsoft.com");
            DoIndependenceWord();
            string content = await getStringTask;
            return content.Length;
        }

        private void DoIndependenceWord()
        {
            Console.WriteLine("Continue working ....");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Manipulate manipulate = new Manipulate();
            Task<int> result = manipulate.AccessTheWebAsync();
            Console.WriteLine(result.Result);
            string a = "";
            
            Console.Read();
        }
    }
}
