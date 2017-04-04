using System;

namespace StringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string message) : base(message)
        {
        }
    }
}