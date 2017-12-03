using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }
        [Display(Name = "Entered By")]
        public string EnteredBy { get; set; }
        
        [ForeignKey("ActivityCategoryId")]
        [Display(Name = "Activity Category")]
        public ActivityCategory ActivityCategory { get; set; }
        public int ActivityCategoryId { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }
    }
}
