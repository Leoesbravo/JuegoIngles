using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Word
    {   
        public int IdPalabra { get; set; }
        public string Palabra { get; set; }
        public ML.Topic Topic { get; set; }
        public string Imagen { get; set; }
        public string PalabraEspanol { get; set; }
        public string SignificadoAlternativo { get; set; }
    }
}
