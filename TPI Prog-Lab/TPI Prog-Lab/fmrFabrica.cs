using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TPI_Prog_Lab
{
    public partial class fmrFabrica : Form
    {
        public fmrFabrica()
        {
            InitializeComponent();
            btnPedidos.Visible = false;
            btnFacturas.Visible = false;
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (SubmenuReporte.Visible == true)
                SubmenuReporte.Visible = false;
            else
                SubmenuReporte.Visible = true;
                btnPedidos.Visible = true;
                btnFacturas.Visible = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormHijo<frmClientes>();
        }
        private void btnAutos_Click(object sender, EventArgs e)
        {
            AbrirFormHijo<frmAutomoviles>();
        }


        private void AbrirFormHijo<Miform>() where Miform : Form, new()
        {
            Form frm;
            frm = OwnedForms.OfType<Miform>().FirstOrDefault();
            if (frm == null)
            {
                frm = new Miform();
                AddOwnedForm(frm);
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                this.Controls.Add(frm);
                this.Tag = frm;
                frm.BringToFront();
                frm.Show();
            }
            else
                frm.BringToFront();
            
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro?", "Salir",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}

