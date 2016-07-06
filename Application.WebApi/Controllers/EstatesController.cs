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
    public class EstatesController : BaseApiController
    {
        public EstatesController() : base()
        {
        }

        public EstatesController(EstatesData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("api/RealEstates/{ID}")]
        public IHttpActionResult GetByID(int id)
        {
            var realEstate = this.data.Estates.Find(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var realEstatesModel = new EstatePartOfFullInfo(realEstate);
            return Ok(realEstatesModel);
        }

        // [HttpGet]
        // [Authorize]
        //   public IHttpActionResult GetByID(int id)
        //   {
        //       var realEstate = this.data.Estates.Find(id);
        //       if (realEstate == null)
        //       {
        //           return NotFound();
        //       }
        //
        //       var realEstatesModel = new EstatePartOfFullInfo(realEstate);
        //       return Ok(realEstatesModel);
        //   }


        //  [Route("api/RealEstates?skip={id}&take={id}")]
        [HttpGet]
        [Route("api/RealEstates")]
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
        [Route("api/RealEstates")]
        public IHttpActionResult Create(EstatesDataDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userID = this.User.Identity.GetUserId();



            var Estate = new Estate
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
            this.data.Estates.Add(Estate);
            this.data.SaveChanges();

            model.ID = Estate.ID;
            model.CreatedOn = Estate.CreatedOn;

            return Ok(model);
        }
        private IEnumerable<EstateDataModelForGuestAll> GetAllSortedByDate()
        {
            return this.data.Estates.All()
                .OrderByDescending(a => a.CreatedOn)
                .Select(EstateDataModelForGuestAll.FromEstates);
        }
    }

}