using System;

namespace BankSystem
{
    public class BankException : Exception
    {
        public DateTime Timestamp = DateTime.Now;

        public BankException(string message) : base(message) { }
        public BankException(string message, Exception inner) : base(message, inner) { }
        protected BankException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
