using System;

namespace QandALibrary
{
    public class QuestionException : Exception
    {
        public QuestionException(string message) : base(message)
        {}

        public QuestionException(string message, Exception inner) : base(message, inner)
        {}
    }
}
