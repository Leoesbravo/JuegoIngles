using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Statistic
    {
        public User User { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int RespuestasCorrectas { get; set; }
        public int ErroresTotales { get; set; }
        public int NumeroTotalPreguntas { get; set; }

    }
}
