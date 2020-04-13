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

namespace SistemaNotas
{
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (sistema_notasEntities db = new sistema_notasEntities())
            {
                var lista = from estudiante in db.Estudiante
                            where estudiante.usuario == txtUsuario.Text
                            && estudiante.contrasena == txtContraseña.Text
                            select estudiante;
                if (lista.Count() > 0)
                {
                    MenuPrincipal m = new MenuPrincipal();
                    m.Show();
                    this.Hide();

                    
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
            }
        }    
    }
}
