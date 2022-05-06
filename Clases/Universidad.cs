using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_13.Clases
{
    public class Universidad
    {
        public string universidades { get; set; }
        public string Nombre { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}