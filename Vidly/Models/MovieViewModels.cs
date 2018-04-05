using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DomainModels;

namespace Vidly.Models
{
    public class RandomViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}