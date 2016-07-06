using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.WebApi.Models
{
    public class RealEstatesDataDetailsModel
    {
        public RealEstatesDataDetailsModel()
        {
           
        }
 

        public static Expression<Func< RealEstate , RealEstatesDataDetailsModel>> FromRealEstates
        {
            get
            {
                return a => new RealEstatesDataDetailsModel
                {
                    //        "Title": "Some very interesting office",
                    // "Description": "You will love it. The view is great!",
                    // "Address": "Mladost 1A, Telerik Academy building",
                    // "Contact": "0888-888-888",
                    // "ConstructionYear": 2005,
                    // "SellingPrice": 120000,
                    // "RentingPrice": 500,
                    // "RealEstateType": 2
                    ID = a.ID,
                    Title = a.Title,
                    Description = a.Description,
                    Address = a.Address,
                    Contact = a.Contact,
                    ConstructionYear = a.ConstructionYear,
                    SellingPrice = a.SellingPrice,
                    RentingPrice = a.RentingPrice,
                    RealEstateType = a.RealEstateType,
                    CanBeRented = (a.RentingPrice != null) ? true : false,
                    CanBeSold = (a.SellingPrice != null) ? true : false,
                };
            }
        }

        [Key]
        public int ID { get; set; }

        public DateTime CreatedOn { get; set; }

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

        public Exam.Models.RealEstateType? RealEstateType { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

       

    }
}