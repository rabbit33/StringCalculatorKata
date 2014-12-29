using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public abstract class BaseNumbersValidator
    {
        private readonly Func<int, bool> invalidNumbersPredicate;
        private readonly Exception exception;

        public IEnumerable<int> InvalidNumbersList { get; set; } 

        protected BaseNumbersValidator(Func<int, bool> invalidNumbersPredicate, Exception exception)
        {
            this.invalidNumbersPredicate = invalidNumbersPredicate;
            this.exception = exception;
        }

        public virtual void Validate(IEnumerable<int> numbers) 
        {
            if (!IsValid(numbers))
            {
                InvalidNumbersList = numbers.Where(invalidNumbersPredicate);
                
                if (exception != null)
                {
                    var message = string.Format("{0}: {1}", exception.Message, string.Join(",", InvalidNumbersList));
                    throw (Exception) Activator.CreateInstance(exception.GetType(), new[] {message});
                }
            }
        }

        public abstract bool IsValid(IEnumerable<int> numbers);
    }
}