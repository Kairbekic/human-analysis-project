using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Helpers
{
    public class SumDigitsHelper
    {
        public static int SumDigits(int number)
        {
            string numberStr = number.ToString();

            int sum = 0;
            foreach (char digitChar in numberStr)
            {
                sum += int.Parse(digitChar.ToString());
            }

            return sum;
        }
        public static int SumDigits(double number) 
        {
            string numberStr = number.ToString();

            int sum = 0;
            foreach (char digitChar in numberStr)
            {
                sum += int.Parse(digitChar.ToString());
            }

            return sum;
        }
    }
}
