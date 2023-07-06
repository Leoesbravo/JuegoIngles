using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Topic
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JuegoInglesEntities context = new DL.JuegoInglesEntities())
                {
                    var query = context.TemaGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Topic topic = new ML.Topic();
                            topic.IdTema = item.IdTema;
                            topic.Tema = item.Tema;
                            topic.EnglishLevel = new ML.EnglishLevel();
                            topic.EnglishLevel.IdNivelIngles = item.IdNivelIngles.Value;

                            result.Objects.Add(topic);
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
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
