using Exam.Data;
using Exam.Models;
using Exam.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Exam.WebApi.Controllers
{
    public class RealEstatesController : BaseApiController
    {
        public RealEstatesController() : base()
        {
        }

        public RealEstatesController(IRealEstatesData data) 
            : base(data)
        {
        }

        [HttpGet]

        public IHttpActionResult GetByID(int id)
        {
            var realEstate = this.data.RealEstates.Find(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var realEstatesModel = new RealEstatePartOfFullInfo(realEstate);
            return Ok(realEstatesModel);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetByID(int id)
        {
            var realEstate = this.data.RealEstates.Find(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var realEstatesModel = new RealEstatePartOfFullInfo(realEstate);
            return Ok(realEstatesModel);
        }

        [HttpGet]

        public IHttpActionResult Get(int skip = 0, int take = 10)
        {
            if (take > 100)
            {
                BadRequest("Invalid take number");
            }

            var RealEstates = GetAllSortedByDate()
                .Skip(skip)
                .Take(take);
                             
            return Ok(RealEstates);
        }

      [HttpPost]
      [Authorize]
      public IHttpActionResult Create(RealEstatesDataDetailsModel model)
      {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userID = this.User.Identity.GetUserId();
      
       
    
          var RealEstate = new RealEstate
          {
              Title = model.Title,
              Description = model.Description,
              CreatedOn = DateTime.Now,
              Address = model.Address,
              Contact = model.Contact,
              ConstructionYear = model.ConstructionYear,
              SellingPrice = model.SellingPrice,
              RentingPrice = model.RentingPrice,
              Type = model.Type,
              CanBeRented = (model.RentingPrice != null) ? true : false,
              CanBeSold = (model.SellingPrice != null) ? true : false,
          };
          this.data.RealEstates.Add(RealEstate);
          this.data.SaveChanges();
    
          model.ID = RealEstate.ID;
          model.CreatedOn = RealEstate.CreatedOn;

            return Ok(model);
        }
        private IEnumerable<RealEstateDataModelForGuestAll> GetAllSortedByDate()
        {
            return this.data.RealEstates.All()
                .OrderByDescending(a => a.CreatedOn)
                .Select(RealEstateDataModelForGuestAll.FromRealEstates);
        }
    }
    
}