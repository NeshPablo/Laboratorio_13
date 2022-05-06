using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_13.Clases
{
    public class Alumno:Persona
    {
        public string Carne { get; set; }
        public List<Nota> Notas { get; set; }
    }
}