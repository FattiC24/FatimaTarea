using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaNotas.Vista;

namespace SistemaNotas.Vista
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void mantenimientoDeEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstudiante Est = new frmEstudiante();
            Est.MdiParent = this;
            Est.Show();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMateria materia = new frmMateria();
            materia.MdiParent = this;
            materia.Show();
        }

        private void notasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNotas Nota = new frmNotas();
            Nota.MdiParent = this;
            Nota.Show();
        }
        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
