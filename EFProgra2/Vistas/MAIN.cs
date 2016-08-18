using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProgra2
{
    public partial class MENU : Form
    {

        ControladorProfesor controladorprofesor = new ControladorProfesor();
        EntidadProfesor entidadprofesor = new EntidadProfesor();  

        public MENU()
        {
            InitializeComponent();
        }


        private void MENU_Load(object sender, EventArgs e)
        {

        }

        private void manProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManProfesor frmpp = new ManProfesor();
            frmpp.MdiParent = this;
            frmpp.Show();
        }

        private void manMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManMateria frmmm = new ManMateria();
            frmmm.MdiParent = this;
            frmmm.Show();
        }

    }
}
