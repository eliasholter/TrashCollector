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

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Weekly Pick-Up Day:")]
        public string PickUpDay { get; set; }
        [Display(Name = "Additional Pick-Up (mm/dd/yyyy):")]
        public string ExtraPickUpDay { get; set; }
        [Display(Name = "Street Address:")]
        public string StreetAddress { get; set; }
        [Display(Name = "City:")]
        public string City { get; set; }
        [Display(Name = "State:")]
        public string State { get; set; }
        [Display(Name = "Zip Code:")]
        public int ZipCode { get; set; }
        [Display(Name = "Balance:")]
        public double Balance { get; set; }
        [Display(Name = "Begin Service Pause (mm/dd/yyyy):")]
        public string SuspendStart { get; set; }
        [Display(Name = "End Service Pause (mm/dd/yyyy):")]
        public string SuspendEnd { get; set; }
        [Display(Name = "Trash Has Been Collected:")]
        public bool PickUpConfirmation { get; set; }

    }
}