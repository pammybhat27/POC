﻿using POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC.ViewModels {
    public class MovieFormViewModel {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movies;

    }
}