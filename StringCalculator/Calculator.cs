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

        public int Add(string numbers)
        {
            if(numbers.Equals(string.Empty))
                return 0;

            int number;
            if (int.TryParse(numbers, out number))
                return number;

            _numbers = numbers;


            SetDelimeter();

            var parsedNumbers = ParseMultipleNumbers();

            throw new 

            return parsedNumbers.Sum();
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


        private IEnumerable<int> ParseMultipleNumbers()
        {
            var splittedNumbers = _numbers.Split(_delimeter);
            var parsedNumbers = splittedNumbers.Select(int.Parse);
            return parsedNumbers;
        }
    }
}