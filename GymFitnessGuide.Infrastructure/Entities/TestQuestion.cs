﻿namespace GymFitnessGuide.Infrastructure.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public required string Question { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
