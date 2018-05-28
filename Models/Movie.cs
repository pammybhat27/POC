using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC.Models {
    public class Movie {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }
    }
}