using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrowing_System
{
    public partial class Borrow : Form
    {
        private ModifyPopup mdPopup;

        public Borrow()
        {
            InitializeComponent();
        }

        private void Borrow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            if (mdPopup == null || mdPopup.IsDisposed)
            {
                mdPopup = new ModifyPopup();
                mdPopup.FormClosed += (s, args) => { mdPopup = null; };
                mdPopup.Show(this); // show owned by this form
            }
            else
            {
                if (!mdPopup.Visible)
                    mdPopup.Show(this);

                mdPopup.BringToFront();
                mdPopup.Focus();
            }
        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
