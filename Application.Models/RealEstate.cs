using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class RealEstate
    {
        public RealEstate()
        {
            this.Comments = new HashSet<Comments>();
        }

        [Key]
        public int ID { get; set; }

        public DateTime CreatedOn { get; set;}

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Range(1800, 2015, ErrorMessage = "Construction year must be more than 1800")]
        public int ConstructionYear { get; set; }

        public RealEstateType? RealEstateType { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
