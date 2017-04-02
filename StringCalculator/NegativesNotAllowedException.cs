using System;

namespace StringCalculator
{
    public class NegativesNotAllowedException : Exception//: ArgumentOutOfRangeException
    {
        public NegativesNotAllowedException(string message) : base(message)
        {
            //this.Message = message;
        }
    }
}