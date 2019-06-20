using System;
using System.Text.RegularExpressions;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            
            string[] vari = Regex.Split(equation, pattern: "[*=]");
            
            var culp = 0;
            for (int i = 0; i < 3; i++)
            {
                if (vari[i].Contains('?'))
                {
                    culp = i;
                    break;
                }
            }
            string res;
            int A, B, C;
            if (culp == 0)
            {
                B = Int32.Parse(vari[1]);
                C = Int32.Parse(vari[2]);
                A = (C / B);
                res = A.ToString();
            }
            else if (culp == 1)
            {
                A = Int32.Parse(vari[0]);
                C = Int32.Parse(vari[2]);
                B = (C / A);
                res = B.ToString();
            }
            else
            {
                A = Int32.Parse(vari[0]);
                B = Int32.Parse(vari[1]);
                C = A * B;
                res = C.ToString();
            }
            if ((res.Length != vari[culp].Length) || A*B!=C)
            {
                return -1;
            }
            int pos = vari[culp].IndexOf('?');
            return (int)Char.GetNumericValue(res[pos]);
        }
    }
}
