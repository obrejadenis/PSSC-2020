using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        { 
        }
        public InvalidQuestionException(string question) : base($"Question: \"{ question}\" cannot have more than 1000 characters length")
        {
        }
    }
}
