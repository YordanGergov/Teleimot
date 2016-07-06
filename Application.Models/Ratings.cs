using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    //Ratings are always between 1 and 5 (integers), inclusive.
    public class Ratings
    {
        [Key]
        public int ID { get; set; }

        [Range(1, 5, ErrorMessage = "Ratings are always between 1 and 5 (integers), inclusive")]
        public int Rating { get; set; }
    }
}
