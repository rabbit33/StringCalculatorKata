using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly IEnumerable<BaseNumbersValidator> validators;

        public StringCalculator(IEnumerable<BaseNumbersValidator> validators)
        {
            this.validators = validators;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var numbersList = SplitNumbers(numbers);

            foreach (var validator in validators)
            {
                validator.Validate(numbersList);
            }

            return numbersList.Sum();
        }

        private IEnumerable<int> SplitNumbers(string numbers)
        {
            char[] delimiters = ComputeDelimiters(ref numbers);

            return numbers.Split(delimiters).Select(int.Parse);
        }

        private char[] ComputeDelimiters(ref string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                char delimiter = numbers[2];
                delimiters.Add(delimiter);

                numbers = numbers.Substring(4);
            }

            return delimiters.ToArray();
        }
    }
}