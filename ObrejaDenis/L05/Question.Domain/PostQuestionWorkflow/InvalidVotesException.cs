using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidVotesException : Exception
    {
        public InvalidVotesException()
        {
        }
        public InvalidVotesException(int votes) : base($"Number of votes: \"{votes}\"  doesn't correspond to sum of individual votes")
        {
        }
    }
}
