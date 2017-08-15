using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Kata
{
    public class StringCalculator
    {
        public static Int32 Add(String numbers)
        {
            if (!String.IsNullOrWhiteSpace(numbers))
            {
                String[] delimiters = GetDelimiters(numbers);

                numbers = RemoveDelimiterLine(numbers);

                String[] numbersList = numbers.Split(delimiters, StringSplitOptions.None);

                ValidateNegativeNumbers(numbersList);

                return numbersList.Where(n => Int32.Parse(n) <= 1000).Sum(n => Int32.Parse(n));
            }

            return 0;
        }

        private static void ValidateNegativeNumbers(String[] numbersList)
        {
            List<String> negativesNumbers = numbersList.Where(x => Int32.Parse(x) < 0).ToList();

            if(negativesNumbers.Any())
            {
                throw new Exception(String.Format("Negatives not allowed: {0}",String.Join(", ", negativesNumbers.ToArray())));
            }
        }

        private static String RemoveDelimiterLine(String numbers)
        {
            if (numbers.Length > 1 && numbers.Substring(0, 2) == "//")
            {
                return numbers.Substring(numbers.IndexOf("\n") + 1);
            }
            else
            {
                return numbers;
            }
        }

        private static String[] GetDelimiters(String numbers)
        {
            String[] delimiters;
            if (numbers.Length > 1 && numbers.Substring(0, 2) == "//")
            {
                String delimiterLine = numbers.Substring(2,numbers.IndexOf("\n")-2);
                delimiters = delimiterLine.Split('[');
                for (Int32 i = 0; i < delimiters.Length;i++ )
                {
                    delimiters[i] = delimiters[i].Replace("]", String.Empty);
                }
            }
            else
            {
                delimiters = new String[2];
                delimiters[0] = "\n";
                delimiters[1] = ",";                
            }

            return delimiters;
        }
    }
}
