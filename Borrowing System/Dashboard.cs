using System;
using System.Data;
using System.Windows.Forms;

namespace Borrowing_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try { DBHelper.RefreshOverdueStatus(); } catch { /* ignore on startup */ }

            LoadDashboardStats();
            LoadAvailableBookList();
        }

        private void LoadDashboardStats()
        {
            try
            {
                DataRow row = DBHelper.GetDashboardStats();
                if (row == null) return;

                label5.Text = row["available_books"].ToString();   // Available Books
                label9.Text = row["borrowed_books"].ToString();    // Borrowed Books
                label7.Text = row["active_loans"].ToString();      // Active Loans
                label4.Text = row["overdue_books"].ToString();     // Overdue
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load dashboard stats:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAvailableBookList()
        {
            try
            {
                DataTable dt = DBHelper.GetAllBooks();
                listBox1.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string avail = row["available"].ToString();
                    string entry = $"{row["title"]}  [{avail} copy/copies]";
                    listBox1.Items.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load book list:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            // Borrow button on the Dashboard
            var main = this.FindForm() as Form1;
            main?.loadForm(new Borrow());
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            // Return button on the Dashboard
            var main = this.FindForm() as Form1;
            main?.loadForm(new Return());
        }
    }
}