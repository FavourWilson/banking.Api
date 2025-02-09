﻿using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class UsersCreateRepo
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Middlename { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public string? MotherMaidenName { get; set; }

        [Required]
        public string? NextOfKin { get; set; }
        [Required]
        public string? Phonenumber { get; set; }

        public Guid RegisterId { get; set; }

    }
        
}
