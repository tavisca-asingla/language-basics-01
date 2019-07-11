using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
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
            if ((res.Length != vari[culp].Length) || A * B != C)
            {
                return -1;
            }
            int pos = vari[culp].IndexOf('?');
            return (int)Char.GetNumericValue(res[pos]);
        }
    }
}
