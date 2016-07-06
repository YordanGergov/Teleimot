using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Comments
    {
        //Content": "Wow, such a bargain! I want to see the place!",
        //    "UserName": "ivaylokenov",
        //    "CreatedOn": "2015-11-22T16:40:03.123"

        //•	Comments have required content between 10 and 500 symbols, inclusive
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
