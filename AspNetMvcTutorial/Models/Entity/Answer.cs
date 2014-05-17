using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        Int32 ID;

        [Required]
        String Name { set; get; }

        [Required]
        String AnswerText { set; get; }

        [Required]
        Boolean Correct { get; set; }

        public Answer(String name, String answerText, Boolean correct)
        {
            this.Name = name;
            this.AnswerText = answerText;
            this.Correct = correct;
        }
    }
}
