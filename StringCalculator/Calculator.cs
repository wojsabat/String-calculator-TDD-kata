using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        private static string _numbers;
        private static string _delimeter;
        private static List<int> _parsedNumbers;

        private static bool HasCustomDelimeter => _numbers.StartsWith("//");

        public static int Add(string numbers)
        {
            if(numbers.Equals(string.Empty))
                return 0;
            if (int.TryParse(numbers, out int number))
                return number;
            _numbers = numbers;
            SetDelimeter();
            _parsedNumbers = ParseMultipleNumbers();
            CheckNegtiveNumber();
            _parsedNumbers = _parsedNumbers.Where(n => n <= 1000).ToList();
            return _parsedNumbers.Sum();
        }

        private static void SetDelimeter()
        {
            if (HasCustomDelimeter)
                HandleCustomDelimeter();
            else if (_numbers.Contains(","))
                _delimeter = ",";
            else
                _delimeter = "\n";
        }

        private static void HandleCustomDelimeter()
        {
            if (_numbers[2] == '[')
                HandleMultipleCharDelimeter();
            else
                _delimeter = _numbers[2].ToString();
            var startIndex = _numbers.IndexOf("\n") + 1;
            _numbers = _numbers.Substring(startIndex);
        }

        private static void HandleMultipleCharDelimeter()
        {
            var endIndex = _numbers.IndexOf(']');
            var length = endIndex - 3;
            _delimeter = _numbers.Substring(3, length);
        }

        private static void CheckNegtiveNumber()
        {
            var negativeNumbers = _parsedNumbers.Where(n => n < 0).ToArray();
            if (negativeNumbers.Count() <= 0)
                return;
            var stringNumbers = negativeNumbers.Select(n => n.ToString());
            var listedNumbers = stringNumbers.Aggregate((current, next) => current + ", " + next);
            var exeptionMessage = "Negatives not allowed: " + listedNumbers;
            throw new NegativesNotAllowedException(exeptionMessage);
        }


        private static List<int> ParseMultipleNumbers()
        {
            var splittedNumbers = _numbers.Split(new []{_delimeter},StringSplitOptions.None);
            var parsedNumbers = splittedNumbers.Select(int.Parse);
            return parsedNumbers.ToList();
        }
    }
}