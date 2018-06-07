﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POC.Models {
    public class Movie {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateReleased { get; set; }

        public DateTime DateAdded { get; set; }

        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }

    }
}