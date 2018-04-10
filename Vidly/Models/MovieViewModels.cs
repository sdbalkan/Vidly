using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DomainModels;

namespace Vidly.Models
{
    public class FormMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}