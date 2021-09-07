using System;

namespace Homework1
{
    // Find Greatest Common Divisor (GCD)
    public class FindGcdService : IFindGcdService
    {
        public int FirstValue { get; set; }

        public int SecondValue { get; set; }


        public int EuclideanGcdMethod(int firstValue, int secondValue)
        {
            firstValue = Math.Abs(firstValue);
            secondValue = Math.Abs(secondValue);

            while (firstValue != secondValue)
            {
                if (firstValue > secondValue)
                {
                    firstValue -= secondValue;
                }
                else
                {
                    secondValue -= firstValue;
                }
            }

            return firstValue;
        }
    }
}
