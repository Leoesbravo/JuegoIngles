//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Palabra
    {
        public int IdPalabra { get; set; }
        public string Palabra1 { get; set; }
        public Nullable<int> IdTema { get; set; }
        public string Imagen { get; set; }
        public string PalabraEspanol { get; set; }
        public string SignificadoAlternativo { get; set; }
    
        public virtual Tema Tema { get; set; }
    }
}
