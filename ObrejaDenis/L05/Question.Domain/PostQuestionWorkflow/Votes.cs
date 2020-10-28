using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [AsChoice]
    public static partial class Votes
    {
        public interface IVotes { }
        public class UnverifiedVotesNumber : IVotes
        {
            public int Votes { get; private set; }
            private UnverifiedVotesNumber(int questionVotes)
            {
                Votes = questionVotes;
            }
            public static Result<UnverifiedVotesNumber> Create(int questionVotes)
            {
                if (IsValidVotesNumber(questionVotes))
                {
                    return new UnverifiedVotesNumber(questionVotes);
                
                }
                else
                    return new Result<UnverifiedVotesNumber>(new InvalidVotesException(questionVotes));
            }
            private static bool IsValidVotesNumber(int questionVotes)
            {
                if (questionVotes != 0)
                {
                    return true;
                }
                return false;
            }
        }
        public class VerifiedVotesNumber : IVotes
        {
            public int Votes { get; private set; }
            internal VerifiedVotesNumber(int questionVotes)
            {
                Votes = questionVotes;
            }
        }
    }
}
