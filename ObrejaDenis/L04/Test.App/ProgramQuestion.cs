using Question.Domain.PostQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.PostQuestionWorkflow.PostQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main2(string[] args)
        {
            List<string> tags = new List<string> {"Redux", "Typescript"};
            var cmd = new PostQuestionCmd("Do we need an interface for our initialValues in Redux?", "Can someone give me an example?", tags);
            var result = PostQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static IPostQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static IPostQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotCreatedResult)
        {
            Console.WriteLine($"Question was not created: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }

        private static IPostQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            Console.WriteLine($"Question {question.QuestionId}");
            return question;
        }

        public static IPostQuestionResult PostQuestion(PostQuestionCmd postQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(postQuestionCommand.Title))
            {
                var errors = new List<string>() { "Question title is not valid" };
                return new QuestionValidationFailed(errors);
            }

            if (string.IsNullOrWhiteSpace(postQuestionCommand.Body))
            {
                var errors = new List<string>() { "Body question is not valid" };
                return new QuestionValidationFailed(errors);
            }
      

            if (new Random().Next(10) > 1)
            {
                return new QuestionNotPosted("Question could not be verified");
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, postQuestionCommand.Title, postQuestionCommand.Body, postQuestionCommand.Tags);

            //execute logic
            return result;
        }
    }
}
