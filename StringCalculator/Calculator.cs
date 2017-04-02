using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private string _numbers;
        private char _delimeter;
        private List<int> _parsedNumbers;

        public int Add(string numbers)
        {
            if(numbers.Equals(string.Empty))
                return 0;

            int number;
            if (int.TryParse(numbers, out number))
                return number;

            _numbers = numbers;


            SetDelimeter();

            _parsedNumbers = ParseMultipleNumbers();

            CheckNegtiveNumber();

            _parsedNumbers = _parsedNumbers.Where(n => n <= 1000).ToList();

            return _parsedNumbers.Sum();
        }

        private void CheckNegtiveNumber()
        {
            var negativeNumbers = _parsedNumbers.Where(n => n < 0);
            if (negativeNumbers.Count() > 0)
            {
                var stringNumbers = negativeNumbers.Select(n => n.ToString());
                var listedNumbers = stringNumbers.Aggregate((current, next) => current + ", " + next);
                var exeptionMessage = "Negatives not allowed: " + listedNumbers;
                throw new NegativesNotAllowedException(exeptionMessage);
            }
        }

        private void SetDelimeter()
        {
            if (_numbers.StartsWith("//"))
                HandleCustomDelimeter();
            else if (_numbers.Contains(","))
                _delimeter = ',';
            else
                _delimeter = '\n';
        }

        private void HandleCustomDelimeter()
        {
            _delimeter = _numbers[2];
            _numbers = _numbers.Substring(4);
        }


        private List<int> ParseMultipleNumbers()
        {
            var splittedNumbers = _numbers.Split(_delimeter);
            var parsedNumbers = splittedNumbers.Select(int.Parse);
            return parsedNumbers.ToList();
        }
    }
}