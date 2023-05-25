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
            decimal? result = null;
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

            List<decimal> numbers = new();
            for (int i = 0; i <= step; i++)
            {
                if (!string.IsNullOrEmpty(stringNumbers[i]))
                {
                    numbers.Add(decimal.Parse(stringNumbers[i]));
                }
            }
            List<decimal> numbersTemp = new List<decimal>(numbers);
            List<string>actionTemp=new List<string>(action);
            
            for (int i=0; i <action.Count(); i++)
            {
                for (int j = 0; j < actionTemp.Count(); j++)
                {
                    if(actionTemp[j] == "*" && j<actionTemp.Count())
                    {
                        numbersTemp[j] *= numbersTemp[j + 1];
                        numbersTemp.RemoveAt(j + 1);
                        actionTemp.RemoveAt(j);
                        break;
                    }

                    if (actionTemp[j] == "/" && j < actionTemp.Count())
                    {
                        numbersTemp[j] /= numbersTemp[j + 1];
                        numbersTemp.RemoveAt(j + 1);
                        actionTemp.RemoveAt(j);
                        break;
                    }
                }
            }

            if (numbersTemp.Count == 1)
            {
                result = numbersTemp[0];
                return decimal.Parse(result.ToString());
            }
            for (int i = 0; i < actionTemp.Count(); i++)
            {
                if (actionTemp[i] == "+")
                {
                    if (result == null)
                    {
                        var x = numbersTemp[i];
                        var y=numbersTemp[i + 1];
                        result=numbersTemp[i] + numbersTemp[i + 1];
                    }
                    else
                    {
                        result += numbersTemp[i + 1];
                    }
                }
                if (actionTemp[i] == "-")
                {
                    if (result == null)
                    {
                        numbersTemp[i] -= numbersTemp[i + 1];
                        result = numbersTemp[i];
                    }
                    else
                    {
                        result -= numbersTemp[i + 1];
                    }
                }
            }
            return decimal.Parse(result.ToString());
        }
    }
}
