using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
 
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PickUpDay { get; set; }
        public string ExtraPickUpDay { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public double Balance { get; set; }
        public string SuspendStart { get; set; }
        public string SuspendEnd { get; set; }
        public bool PickUpConfirmation { get; set; }

    }
}