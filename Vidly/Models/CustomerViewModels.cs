using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DomainModels;

namespace Vidly.Models
{
    public class FormCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}