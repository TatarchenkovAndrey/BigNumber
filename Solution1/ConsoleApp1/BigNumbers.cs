    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BigNumber
    {
        private string sourceNumber;
    
        public BigNumber(string x)
        {
            if (string.IsNullOrEmpty(x))
            {
                sourceNumber = null;
                return;
            }
            var secondNumber = 0;
            var i = 0;
            foreach(var number in x)
            {
                try
                {
                    var firstNumber = (int)char.GetNumericValue(number);
                    secondNumber += firstNumber;
                    sourceNumber = x;
                }
                catch (Exception e)
                {
                    sourceNumber = null;
                    break;
                }

                if (x.Length != 1 && i != 0 && secondNumber == 0)
                {
                    sourceNumber = null;
                    return;
                }

                i += 1;
            }
        }

        public override string ToString()
        {
            return sourceNumber;
        }

        public static BigNumber operator +(BigNumber firstNumber, BigNumber secondNumber)
        {
            int[] resultArray;
            var firstArray = new int[firstNumber.sourceNumber.Length];
            firstArray = CreateArray(firstArray, firstNumber);

            
            var secondArray = new int[secondNumber.sourceNumber.Length];
            secondArray = CreateArray(secondArray, secondNumber);
            
            if (firstNumber.sourceNumber.Length >= secondNumber.sourceNumber.Length)
            {
                resultArray = new int[firstNumber.sourceNumber.Length];
                resultArray = Sum(firstArray, secondArray, firstNumber, secondNumber);
            }
            else
            {
                resultArray = new int[secondNumber.sourceNumber.Length];
                resultArray = Sum(secondArray, firstArray, secondNumber,firstNumber);
            }

            Array.Reverse(resultArray);
            var res = String.Concat(resultArray);
            var res1 = new BigNumber(res);

            return res1;
        }

        private static int[] Sum(int[] firstArray, int[] secondArray, BigNumber firstNumber, BigNumber secondNumber)
        {
            int temp = 0;
            var resultArray = new int[firstNumber.sourceNumber.Length];
            for (int n = 0; n < firstNumber.sourceNumber.Length; n++)
            {
                if ((n + 1) <= secondNumber.sourceNumber.Length)
                {
                    if (n < firstNumber.sourceNumber.Length - 1)
                    {
                        resultArray[n] = (firstArray[n] + secondArray[n] + temp) % 10;
                        temp = (firstArray[n] + secondArray[n] + temp) / 10;
                    }
                    else
                    {
                        resultArray[n] = firstArray[n] + secondArray[n] + temp;
                    }
                }
                else
                {
                    if (n < firstNumber.sourceNumber.Length - 1)
                    {
                        resultArray[n] = (firstArray[n] + temp) % 10;
                        temp = (firstArray[n] + temp) / 10;
                    }
                    else
                    {
                        resultArray[n] = firstArray[n] + temp;
                    }
                }
            }

            return resultArray;
        }

        private static int[] CreateArray(int[] array, BigNumber number)
        {
            var i = 0;
            foreach (var item in number.sourceNumber)
            {
                array[i] = (int)char.GetNumericValue(item);
                i += 1;
            }
            
            Array.Reverse(array);
            return array;
        }

    }