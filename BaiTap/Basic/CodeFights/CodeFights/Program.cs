using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    class Program
    {

        //using Linq to search all longest string
        #region allLongestString
        static object allLongestStrings(string[] inputArray)
        {
            int len = inputArray.Max(_ => _.Length);
            return inputArray.Where(_ => _.Length == len);
        }
        #endregion

        #region commonCharacterCount
        int commonCharacterCount(string s1, string s2)
        {
            return s1.Distinct().Sum(_ => Math.Min(s1.Count(l => l == _), s2.Count(l => l == _)));
        }
        #endregion

        #region Sort By Height
        static object sortByHeight(int[] a)
        {
            int[] people = a.Where(p => p >= 0).OrderBy(p => p).ToArray();
            int i = 0;
            Array.Reverse(people);

            return a.Select(p => p >= 0 ? people[i++] : -1);
        }
        #endregion

        #region reverseParentheses
        static string reverseParentheses(string s)
        {
            return reverse(s);
        }

        static string reverse(string s)
        {
            var l = s.LastIndexOf('(');
            if (l == -1) return s;
            var r = s.IndexOf(')', l);
            var arr = s.Substring(l + 1, r - l - 1).ToCharArray();
            Array.Reverse(arr);
            return reverse(s.Substring(0, l) + new string(arr) + s.Substring(r + 1));
        }

        static bool areSimilar(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        static bool palindromeRearranging(string s)
        {
            var group = s.GroupBy(_ => _);
            return group.Where(_ => _.Count() % 2 == 1).Count() <= 1;
        }
        #endregion

        #region XauNganNhat

        /// <summary>
        /// Trả về độ dài của xâu không có chữ nào lặp lại
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int XauNganNhat(string input)
        {
            var temp = input.Distinct();
            return temp.Count();
        }

        #endregion


        static void Main(string[] args)
        {
            string[] arr = { "abc", "abx", "axx","abx","abc"};
            Array.Sort(arr);
            //Console.WriteLine(a.Sum(_=>(int)_));
            Console.Read();
        }
    }
}