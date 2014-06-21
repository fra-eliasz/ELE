using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        Int32 ID;

        [Required]
        public String Name { set; get; }

        [Required]
        public String AnswerText { set; get; }

        [Required]
        public Boolean Correct { get; set; }

        public Answer(String name, String answerText, Boolean correct)
        {
            this.Name = name;
            this.AnswerText = answerText;
            this.Correct = correct;
        }
    }
}
