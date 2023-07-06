using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class TopicController : ApiController
    {
        [HttpGet]
        [Route("api/Topic/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Topic.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
