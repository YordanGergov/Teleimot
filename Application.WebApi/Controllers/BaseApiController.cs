using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        public IEstatesData data;

        public BaseApiController()
            : this(new EstatesData(new EstatesDbContext()))
        {

        }

        public BaseApiController(IEstatesData data)
        {
            this.data = data;
        }

        public IEstatesData Data
        {
            get
            {
                return this.data;
            }
            
        }
    }
}
