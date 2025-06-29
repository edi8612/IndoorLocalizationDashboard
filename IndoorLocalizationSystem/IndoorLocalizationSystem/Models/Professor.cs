﻿using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoorLocalizationSystem.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the professor
        public string Name { get; set; } // Name of the professor

        public int UserId { get; set; } // Foreign key to the User table

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property to the User entity

        public List<Course> Courses { get; set; } = new();
    }
}

