using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        Int32 ID;

        [Required]
        String Name { set; get; }

        [Required]
        String QuestionText { set; get; }

        [Required]
        List<Answer> Answers { set; get; }

        public Quiz(String name, String questionText, List<Answer> answers)
        {
            this.Name = name;
            this.QuestionText = questionText;
            this.Answers = answers;
        }
    }
}
