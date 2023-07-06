using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Word
    {
        public static ML.Result GetWordsToPlay(int idTema1, int idTema2, int idTema3)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JuegoInglesEntities context = new DL.JuegoInglesEntities())
                {
                    var query = context.GetWordsToPlay(idTema1,idTema2,idTema3).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Word word = new ML.Word();
                            word.IdPalabra = item.IdPalabra;
                            word.Palabra = item.Palabra;

                            word.Topic = new ML.Topic();
                            word.Topic.IdTema = item.IdTema.Value;

                            word.PalabraEspanol = item.PalabraEspanol;

                            result.Objects.Add(word);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
