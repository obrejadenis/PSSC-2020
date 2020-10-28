﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidTagException : Exception
    {
        public InvalidTagException()
        {
        }
        public InvalidTagException(List<string> tags) : base($"Question has \"{tags}\" tags. A question must have at least 1 tag and at most 3 tags")
        {
        }
        
    }
}
