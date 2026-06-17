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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }


        private void cyberButton2_Click(object sender, EventArgs e)
        {
            var main = this.FindForm() as Form1;
            if (main != null)
            {
                main.loadForm(new Borrow());
            }
        }
    }
}
