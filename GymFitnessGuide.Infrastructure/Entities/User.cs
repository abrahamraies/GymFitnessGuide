﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsEnabled { get; set; } = true;
        
        public ICollection<TestAnswer> TestAnswers { get; set; } = [];
        public ICollection<UserCategory> UserCategories { get; set; } = [];
    }
}
