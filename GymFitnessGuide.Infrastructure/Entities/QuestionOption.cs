﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("questionoptions")]
    public class QuestionOption
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int QuestionId { get; set; }
        public TestQuestion Question { get; set; } = null!;
    }
}
