using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class StatisticController : ApiController
    {
        // GET: Statistic
        [HttpGet]
        [Route("api/Statistic/GetStatistic/{idUser}")]
        public IHttpActionResult GetStatistic(int idUser)
        {
            var result = BL.Statistic.GetStatistic(idUser);
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