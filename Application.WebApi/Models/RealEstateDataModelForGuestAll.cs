using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.WebApi.Models
{
    public class RealEstateDataModelForGuestAll
    {
        public RealEstateDataModelForGuestAll()
        {

        }


        public static Expression<Func<RealEstate, RealEstateDataModelForGuestAll>> FromRealEstates
        {
            get
            {
                return a => new RealEstateDataModelForGuestAll
                {
      //            "Id": 2,
      // "Title": "My house is for sale!",
      // "SellingPrice": 28000,
      // "RentingPrice": null,
      // "CanBeSold": true,
      // "CanBeRented": false

                    ID = a.ID,
                    Title = a.Title,                  
                    SellingPrice = a.SellingPrice,
                    RentingPrice = a.RentingPrice,              
                    CanBeRented = (a.RentingPrice != null) ? true : false,
                    CanBeSold = (a.SellingPrice != null) ? true : false,
                };
            }
        }


        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        // "Id": 2,
        // "Title": "My house is for sale!",
        // "SellingPrice": 28000,
        // "RentingPrice": null,
        // "CanBeSold": true,
        // "CanBeRented": false
        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

    }
}