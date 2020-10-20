﻿using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface IPostQuestionResult { }

        public class QuestionPosted : IPostQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; } // question title
            public string Body { get; private set; } // question body ( question description )
            public List<string> Tags { get; private set; }  // question tags . Am folosit lista pentru ca putem adauga mai multe tags.

            public QuestionPosted(Guid questionId, string title, string body, List<string> tags)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
            }
        }

        public class QuestionNotPosted : IPostQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
