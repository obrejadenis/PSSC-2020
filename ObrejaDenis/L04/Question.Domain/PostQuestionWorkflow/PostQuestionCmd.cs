using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    // product type = Title*Body*Tags
    public struct PostQuestionCmd
    {
        [MaxLength(150)]
        [Required]
        public string QuestionTitle { get; private set; } 
        [Required]
        public string QuestionBody { get; set; } 
        [Required]
        public List<string> QuestionTags { get; set; } 
        
        public PostQuestionCmd(string title, string body, List<string> tags)
        {
            QuestionTitle = title;
            QuestionBody = body;
            QuestionTags = tags;
        }
    }
}
