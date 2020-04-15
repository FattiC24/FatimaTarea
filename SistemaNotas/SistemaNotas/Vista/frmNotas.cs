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
    public partial class frmNotas : Form
    {
        public frmNotas()
        {
            InitializeComponent();
        }
        notas notas = new notas();

        void cargardatos()
        {
            using (sistema_notasEntities bd = new sistema_notasEntities())
            {
                var innerJoin = from tbNotas in bd.notas
                                from tbEstudiante in bd.Estudiante
                                from tbMateria in bd.materia
                                where tbNotas.id_estudiante == tbEstudiante.id_estudiante
                                && tbNotas.id_materia == tbMateria.id_materia

                                select new
                                {
                                    Id = tbNotas.id_notas,
                                    Nombre = tbEstudiante.nombre_estudiante,
                                    Materia = tbMateria.nombre_materia,
                                    Nota = tbNotas.nota,
                                    idMateria = tbMateria.id_materia,
                                    idEstudiante = tbEstudiante.id_estudiante
                                };
                foreach (var iterardatos in innerJoin)
                {
                    dtvNotas.Rows.Add(iterardatos.Id, iterardatos.Nombre, iterardatos.Materia, iterardatos.Nota, iterardatos.idMateria, iterardatos.idEstudiante);
                }

            }

        }
        void limpiardatos()
        {
            txtIdAlumno.Text = "";
            txtIdMateria.Text = "";
            txtNota.Text = "";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                notas.id_estudiante = int.Parse(txtIdAlumno.Text);
                notas.id_materia = int.Parse(txtIdMateria.Text);
                notas.nota = double.Parse(txtNota.Text);

                db.notas.Add(notas);
                db.SaveChanges();
            }
            dtvNotas.Rows.Clear();
            cargardatos();
            limpiardatos();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                String Id = dtvNotas.CurrentRow.Cells[0].Value.ToString();
                int idC = int.Parse(Id);
                notas = db.notas.Where(VerificarID => VerificarID.id_notas == idC).First();
                //notas.IdAlumno = txtIdAlumno.Text;
                //notas.IdMateria = txtIdMateria.Text;
                notas.nota = double.Parse(txtNota.Text);
                db.Entry(notas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            dtvNotas.Rows.Clear();
            cargardatos();
            limpiardatos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities bd = new sistema_notasEntities())
            {
                String id = dtvNotas.CurrentRow.Cells[0].Value.ToString();

                notas = bd.notas.Find(int.Parse(id));
                bd.notas.Remove(notas);
                bd.SaveChanges();
            }
            dtvNotas.Rows.Clear();
            cargardatos();
            limpiardatos();
        }
        private void dtvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String IdAlumno = dtvNotas.CurrentRow.Cells[5].Value.ToString();
            String IdMateria = dtvNotas.CurrentRow.Cells[4].Value.ToString();
            String Nota = dtvNotas.CurrentRow.Cells[3].Value.ToString();
            txtIdAlumno.Text = IdAlumno;
            txtIdMateria.Text = IdMateria;
            txtNota.Text = Nota;
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            //dtvNotas.Rows.Clear();
            cargardatos();
        }


        private void dtvNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        
    }
}
