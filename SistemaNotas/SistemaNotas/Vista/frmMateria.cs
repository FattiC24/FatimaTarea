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
    public partial class frmMateria : Form
    {
        public frmMateria()
        {
            InitializeComponent();
        }
        materia Materia = new materia();
        void cargardatos()
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                var Materia = db.materia;
                foreach (var iterardatosMateria in Materia)
                {
                    dtvMateria.Rows.Add(iterardatosMateria.id_materia, iterardatosMateria.nombre_materia);
                }
                //dtvMateria.DataSource = db.Materia.ToList();
            }

        }
        void limpiardatos()
        {
            txtId_materia.Text = "";
            txtnombre_materia.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            using (sistema_notasEntities db = new sistema_notasEntities())
            {
               
                Materia.nombre_materia = txtnombre_materia.Text;
                

                db.materia.Add(Materia);
                db.SaveChanges();
            }
            dtvMateria.Rows.Clear();
            cargardatos();
            limpiardatos();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities bd = new sistema_notasEntities())
            {
                String id = dtvMateria.CurrentRow.Cells[0].Value.ToString();

                int idC = int.Parse(id);

                Materia = bd.materia.Where(VerificarId => VerificarId.id_materia == idC).First();
                Materia.nombre_materia = txtnombre_materia.Text;
                

                bd.Entry(Materia).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
            dtvMateria.Rows.Clear();
            cargardatos();
            limpiardatos();
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal m = new MenuPrincipal();
            m.Show();
            this.Hide();
        }
    }
}
