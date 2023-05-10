using EjercicioDos.Dato;
using EjercicioDos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioDos
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        PersonaAdmin admin = new PersonaAdmin();
        private void Inicializar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Telefono");
            tabla.Columns.Add("Correo");
            tabla.Columns.Add("Foto");
            tabla.Columns.Add("Cursos");
        }

        public Form1()
        {
            InitializeComponent();
            Consultar();
        }

        private void Consultar()
        {
            Inicializar();
            List<Persona> lista = admin.Consultar();
            foreach(var item in lista)
            {
                DataRow row = tabla.NewRow();
                row["Nombre"] = item.Nombre;
                row["Apellido"] = item.Apellido;
                row["Cedula"] = item.Cedula;
                row["Telefono"] = item.Telefono;
                row["Correo"] = item.Correo;
                row["Foto"] = item.Foto;
                row["Cursos"] = item.Cursos;
                tabla.Rows.Add(row);
            }
        }

        private void Guardar()
        {
            Persona persona = new Persona()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Cedula = txtCedula.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Foto = txtfoto.Text,
                Cursos = int.Parse(txtCursos.Text)
            };
            admin.Guardar(persona);
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtfoto.Text = "";
            txtCursos.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Consultar();
            Limpiar();
        }
    }
}
