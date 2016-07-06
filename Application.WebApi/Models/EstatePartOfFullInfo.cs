using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.WebApi.Models
{
    public class EstatePartOfFullInfo
    {
        //      "CreatedOn": "2015-11-22T16:06:27.97",
        //  "ConstructionYear": 2005,
        //  "Address": "Mladost 1A, Telerik Academy building",
        //  "estateestateType": "Office",
        //  "Description": "You will love it. The view is great!",
        //  "Id": 1,
        //  "Title": "Some very interesting office",
        //  "SellingPrice": 120000,
        //  "RentingPrice": 500,
        //  "CanBeSold": true,
        //  "CanBeRented": true

        public EstatePartOfFullInfo(Estate estate)
        {
            this.ID = estate.ID;
            this.Title = estate.Title;
            this.Description = estate.Description;
            this.Address = estate.Address;
            this.ConstructionYear = estate.ConstructionYear;
            this.SellingPrice = estate.SellingPrice;
            this.RentingPrice = estate.RentingPrice;
            this.Type = estate.Type;
            this.CanBeRented = (estate.RentingPrice != null) ? true : false;
            this.CanBeSold = (estate.SellingPrice != null) ? true : false;
        }

        //     "CreatedOn": "2015-11-22T16:06:27.97",
        //  "ConstructionYear": 2005,
        //  "Address": "Mladost 1A, Telerik Academy building",
        //  "estateestateType": "Office",
        //  "Description": "You will love it. The view is great!",
        //  "Id": 1,
        //  "Title": "Some very interesting office",
        //  "SellingPrice": 120000,
        //  "RentingPrice": 500,
        //  "CanBeSold": true,
        //  "CanBeRented": true

        public DateTime CreatedOn { get; set; }

        [Range(1800, 2015, ErrorMessage = "Construction year must be more than 1800")]
        public int ConstructionYear { get; set; }

        [Required]
        public string Address { get; set; }

        public Exam.Models.Type? Type { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }



    }
}