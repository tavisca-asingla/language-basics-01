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

            string[] fields = Regex.Split(equation, pattern: "[*=]");

            var culpritField = 0;
            for (int index = 0; index < 3; index++)
            {
                if (fields[index].Contains('?'))
                {
                    culpritField = index;
                    break;
                }
            }
            string result;
            int operand1, operand2, operand3;
            if (culpritField == 0)
            {
                operand2 = Int32.Parse(fields[1]);
                operand3 = Int32.Parse(fields[2]);
                operand1 = (operand3 / operand2);
                result = operand1.ToString();
            }
            else if (culpritField == 1)
            {
                operand1 = Int32.Parse(fields[0]);
                operand3 = Int32.Parse(fields[2]);
                operand2 = (operand3 / operand1);
                result = operand2.ToString();
            }
            else
            {
                operand1 = Int32.Parse(fields[0]);
                operand2 = Int32.Parse(fields[1]);
                operand3 = operand1 * operand2;
                result = operand3.ToString();
            }
            /*
            if the given equation is not possible to occur return -1
            This means this problem does not have a valid solution if operand1 * operand2 != operand3  or 
            if culpritfield length is not equal to resultfield length (See Test Case 4)
            */
            if ((result.Length != fields[culpritField].Length) || operand1 * operand2 != operand3)
            {
                return -1;
            }
            int position = fields[culpritField].IndexOf('?');
            return (int)Char.GetNumericValue(result[position]);
        }
    }
}
