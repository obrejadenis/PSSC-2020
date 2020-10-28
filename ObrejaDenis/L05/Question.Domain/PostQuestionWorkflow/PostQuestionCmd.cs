﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    // product type = Title*Body*Tags
    public struct PostQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        [MaxLength(1000)]
        public string Body { get; private set; }
        [Required]
        public List<string> Tags { get; set; } 
        [Required]
        public int Votes { get; private set; }

        public PostQuestionCmd(string questionTitle, string questionBody, List<string> questionTags,int questionVotes)
        {
            Title = questionTitle;
            Body = questionBody;
            Tags = questionTags;
            Votes = questionVotes;
        }
    }
}
