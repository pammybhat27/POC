using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC.Models {
    public class Movie {
        public int Id { get; set; }

        public DateTime DateReleased { get; set; }

        public DateTime DateAdded { get; set; }

        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }
        public byte GenreId { get; set; }


    }
}