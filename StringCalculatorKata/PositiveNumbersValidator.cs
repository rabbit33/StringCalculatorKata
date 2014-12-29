using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class PositiveNumbersValidator : BaseNumbersValidator
    {
        public PositiveNumbersValidator(Func<int, bool> invalidNumbersPredicate, Exception exception) : base(invalidNumbersPredicate, exception)
        {
        }

        public override bool IsValid(IEnumerable<int> numbers)
        {
            return numbers.All(n => n >= 0);
        }
    }
}