using Laboratorio_13.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_13
{
    public partial class Eliminar : System.Web.UI.Page
    {
        static List<Nota> NotasTemp = new List<Nota>();
        static List<Alumno> AlumnoTemp = new List<Alumno>();
        static List<Universidad> UniversidadTemp = new List<Universidad>();

        static string carne;
        protected void Page_Load(object sender, EventArgs e)
        {
            string archivo = Server.MapPath("Datos.Json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            UniversidadTemp = JsonConvert.DeserializeObject<List<Universidad>>(json);

        }
        private void Guardar()
        {
            string json = JsonConvert.SerializeObject(UniversidadTemp);
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (var universidad in UniversidadTemp)
            {
                Alumno alumno = universidad.Alumnos.Find(c => c.Carne == carne);
                
                if (alumno != null)
                {
                    universidad.Alumnos.Remove(alumno);
                }
            }
            Guardar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            carne = TextBox1.Text;
            bool encontrado = false;

            foreach(var universidad in UniversidadTemp)
            {
                AlumnoTemp = universidad.Alumnos;
                Alumno alumno = universidad.Alumnos.Find(c =>c.Carne == carne);
                if(alumno != null)
                {
                    TextBox2.Text = alumno.Nombre;
                    TextBox3.Text = alumno.Apellido;
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Response.Write("<script>alert('No se encuentra el alumno')</script>");
            }

        }
    }
}