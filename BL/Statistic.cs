using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Statistic
    {
        public static ML.Result GetStatistic(int idUser)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JuegoInglesEntities context = new DL.JuegoInglesEntities())
                {
                    var query = context.GetStatistic(idUser).ToList();
                    if(query.Count  > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Statistic statistic = new ML.Statistic();

                            statistic.User = new ML.User();
                            statistic.User.IdUsuario = item.IdUsuario;

                            statistic.EnglishLevel = new ML.EnglishLevel();
                            statistic.EnglishLevel.IdNivelIngles = item.IdNivelIngles;

                            statistic.RespuestasCorrectas = item.RespuestasCorrectas.Value;
                            statistic.ErroresTotales = item.ErroresTotales.Value;
                            statistic.NumeroTotalPreguntas = item.NumeroTotalPreguntas.Value;

                            result.Objects.Add(statistic);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
