using System;

namespace StringCalculatorKata
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string message)
            : base(message)
        {
        }
    }
}