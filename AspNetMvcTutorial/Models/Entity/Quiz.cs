using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        Int32 ID;

        [Required]
        public Int16 Number { set; get; }

        [Required]
        public String Name { set; get; }

        [Required]
        public String QuestionText { set; get; }

        [Required]
        public List<Answer> Answers { set; get; }

        public Quiz(Int16 number, String name, String questionText, List<Answer> answers)
        {
            this.Number = number;
            this.Name = name;
            this.QuestionText = questionText;
            this.Answers = answers;
        }
    }
}
