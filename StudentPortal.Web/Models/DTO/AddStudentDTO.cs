﻿using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.DTO
{
    public class AddStudentDTO
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
