using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/User/GetByUserName/{userName}")]
        public IHttpActionResult GetByUserName(string userName)
        {
            var result = BL.User.GetByUserName(userName);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpPost]
        [Route("api/User/Add")]
        public IHttpActionResult Add([FromBody]ML.User user)
        {
            var result = BL.User.Add(user);
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
