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
    public partial class Actualizar : System.Web.UI.Page
    {

        static public List<Universidad> UniTemp = new List<Universidad>();
        static public List<Alumno> alumnos = new List<Alumno>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeerJson();
            }
        }
        private void LeerJson()
        {
            string archivo = Server.MapPath("Datos.Json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            alumnos = JsonConvert.DeserializeObject<List<Alumno>>(json);

            /*string archivo2 = Server.MapPath("Universidades.Json");
            StreamReader jsonStream2 = File.OpenText(archivo);
            string json2 = jsonStream.ReadToEnd();
            jsonStream.Close();
            UniTemp = JsonConvert.DeserializeObject<List<Universidad>>(json2);
            */
        }

        private void ActualizarJson()
        {
            string json = JsonConvert.SerializeObject(UniTemp);
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            foreach (var universidad in UniTemp)
            {
                alumnos = universidad.Alumnos;
                Alumno Alumnosaux = alumnos.Find(c => c.Carne == TextBox1.Text);
                if (Alumnosaux != null)
                {
                    TextBox2.Text = Alumnosaux.Nombre;
                    TextBox3.Text = Alumnosaux.Apellido;
                    encontrado = true;
                }
                if (!encontrado)
                {
                    TextBox1.Text = "";
                    Response.Write("<script>alert('Alumno no encontrado')</acript>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (var universidad in UniTemp)
            {
                alumnos = universidad.Alumnos;
                Alumno Alumnob = alumnos.Find(b => b.Carne == TextBox3.Text);
                if (Alumnob != null)
                {
                    Alumnob.Nombre = TextBox2.Text;
                    Alumnob.Apellido = TextBox3.Text;

                }
            }
            ActualizarJson();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}