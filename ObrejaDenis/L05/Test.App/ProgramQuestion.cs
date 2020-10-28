using LanguageExt;
using Question.Domain.PostQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.PostQuestionWorkflow.PostQuestionResult;
using static Question.Domain.PostQuestionWorkflow.Question;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string> { "Redux", "Typescript" };

            var result = UnverifiedQuestion.Create("Do we need an interface for our initialValues in Redux?", tags);

            result.Match(
                Succ: question =>
                {
                    VoteQuestion(question);
                    Console.WriteLine("Question can be voted!");
                    return Unit.Default;
                },
                Fail: ex =>
                {
                    Console.WriteLine($"Invalid question. Reason:{ex.Message}");
                    return Unit.Default;
                }

                );

            Console.ReadLine();
        }

        private static void VoteQuestion(UnverifiedQuestion question)
        {
            var verifiedQuestionResult = new VerifyQuestionService().VerifyQuestion(question);
            verifiedQuestionResult.Match(
                    VoteQuestion =>
                    {
                        new VoteService().Vote(VoteQuestion).Wait();
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("You cannot vote the question!");
                        return Unit.Default;
                    }
                    );
        }
    }
}
