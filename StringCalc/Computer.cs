using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Computer
    {

        public decimal Calc(string input)
        {
            decimal result = 0;
            int step = 0;
            string[] stringNumbers = new string[input.Length];
            List<string> action = new();
            foreach (var i in input)
            {
                if (i != '+' && i != '-' && i != '*' && i != '/')
                {
                    if(i == '.')
                    {
                        stringNumbers[step] = stringNumbers[step] + ',';
                    }
                    else
                    {
                        stringNumbers[step] = stringNumbers[step] + i;
                    }
                }
                else
                {
                    action.Add(i.ToString());
                    step++;
                }
            }

            decimal[] numbers = new decimal[step + 1];
            for (int i = 0; i <= step; i++)
            {
                if (!string.IsNullOrEmpty(stringNumbers[i]))
                {
                    numbers[i] = decimal.Parse(stringNumbers[i]);
                }
            }
            result = numbers[0];
            for (int i = 0; i < action.Count(); i++)
            {
                if (action[i] == "+")
                {
                    result += numbers[i + 1];
                }
                if (action[i] == "-")
                {
                    result -= numbers[i + 1];
                }
                if (action[i] == "*")
                {
                    result *= numbers[i + 1];
                }
                if (action[i] == "/")
                {
                    result /= numbers[i + 1];
                }
            }
            return result;
        }
    }
}
