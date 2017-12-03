using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class ActivityCategory
    {
        [Key]
        public int ActivityCategoryId { get; set; }
        [Display(Name = "Activity Category")]
        public string ActivityDescription { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
