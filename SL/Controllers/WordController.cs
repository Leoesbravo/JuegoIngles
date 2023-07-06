using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class WordController : ApiController
    {
        [HttpGet]
        [Route("api/Word/GetWords/{tema1}/{tema2}/{tema3}")]
        public IHttpActionResult GetWords(int tema1, int tema2, int tema3)
        {
            var result = BL.Word.GetWordsToPlay(tema1, tema2, tema3);
            if (result.Correct)
            {
                ML.Result resultJueo = new ML.Result();
                resultJueo.Objects = result.Objects.Take(4).ToList();
                ML.Result resultPalabras = new ML.Result();
                resultPalabras.Objects = result.Objects.Take(6).ToList();

                var response = new { ResultJuego = resultJueo, ResultPalabras = resultPalabras };
                return Ok(response);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

    }
}