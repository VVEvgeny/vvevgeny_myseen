﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MySeenWeb.Models.Tables
{
    public class Films
    {
        [Key]
        public int Id { get; set; }
        //Foreign key for Standard
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public DateTime DateSee { get; set; }
        public int Genre { get; set; }
        public int Rating { get; set; }
        public DateTime DateChange { get; set; }
        public bool? isDeleted { get; set; }
    }
}