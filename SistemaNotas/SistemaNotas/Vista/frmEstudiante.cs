using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaNotas.Model;
using SistemaNotas.Vista;

namespace SistemaNotas.Vista
{
    public partial class frmEstudiante : Form
    {
        public frmEstudiante()
        {
            InitializeComponent();
            
        }
        Estudiante estudiante = new Estudiante();

        void cargardatos()
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                var Estudiante = db.Estudiante;
                foreach(var iterardatosEstudiante in Estudiante)
                {
                   dtvEstudiante.Rows.Add(iterardatosEstudiante.id_estudiante, iterardatosEstudiante.nombre_estudiante, iterardatosEstudiante.apellido,
                       iterardatosEstudiante.usuario, iterardatosEstudiante.contrasena);
                }
                //dtvEstudiante.DataSource = db.Estudiante.ToList();
            }

        }
        void limpiardatos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                estudiante.nombre_estudiante = txtNombre.Text;
                estudiante.apellido = txtApellido.Text;
                estudiante.usuario = txtUsuario.Text;
                estudiante.contrasena = txtContraseña.Text;

                db.Estudiante.Add(estudiante);
                db.SaveChanges();
            }
            dtvEstudiante.Rows.Clear();
            cargardatos();
            limpiardatos();
        }

        private void dtvEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Estudiante = dtvEstudiante.CurrentRow.Cells[1].Value.ToString();
            String apellido = dtvEstudiante.CurrentRow.Cells[2].Value.ToString();
            String Usuario = dtvEstudiante.CurrentRow.Cells[3].Value.ToString();
            String Contraseña = dtvEstudiante.CurrentRow.Cells[4].Value.ToString();
            txtNombre.Text = Estudiante;
            txtApellido.Text = apellido;
            txtUsuario.Text = Usuario;
            txtContraseña.Text = Contraseña;

            
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities bd = new sistema_notasEntities())
            {
                String id = dtvEstudiante.CurrentRow.Cells[0].Value.ToString();

                int idC = int.Parse(id);

                estudiante = bd.Estudiante.Where(VerificarId => VerificarId.id_estudiante == idC).First();
                estudiante.nombre_estudiante = txtNombre.Text;
                estudiante.apellido = txtApellido.Text;
                estudiante.usuario = txtUsuario.Text;
                estudiante.contrasena = txtContraseña.Text;

                bd.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
            dtvEstudiante.Rows.Clear();
            cargardatos();
            limpiardatos();

        }
        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            
            cargardatos();
            
        }


        private void dtvEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

