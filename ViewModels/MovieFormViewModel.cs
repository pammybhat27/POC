using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using POC.Models;

namespace POC.ViewModels {
    public class MovieFormViewModel {
        public int? Id  { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateReleased { get; set; }

        public DateTime DateAdded { get; set; }

        public byte NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genre { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            DateReleased = movie.DateReleased;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }



    }
}