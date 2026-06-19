using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Borrowing_System
{
    public partial class Return : Form
    {
        private int _selectedRecordId = -1;

        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            customButton1.Click += customButton1_Click;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            LoadActiveLoans();
        }

        private void LoadActiveLoans()
        {
            try
            {
                // v_borrow_details columns:
                // record_id, school_id, full_name, program, contact_no, book_title,
                // date_borrowed, due_date, date_returned, amount_paid, status
                DataTable dt = DBHelper.GetActiveBorrowRecords();

                dataGridView1.Rows.Clear();
                int rowNum = 1;

                foreach (DataRow row in dt.Rows)
                {
                    int idx = dataGridView1.Rows.Add(
                        rowNum++,
                        row["school_id"],
                        row["full_name"],
                        row["program"],
                        row["contact_no"],
                        row["book_title"],
                        row["date_borrowed"] == DBNull.Value ? "" :
                            Convert.ToDateTime(row["date_borrowed"]).ToString("MM/dd/yyyy"),
                        row["due_date"] == DBNull.Value ? "" :
                            Convert.ToDateTime(row["due_date"]).ToString("MM/dd/yyyy"),
                        row["amount_paid"]
                    );

                    var gridRow = dataGridView1.Rows[idx];
                    gridRow.Tag = row["record_id"];

                    if (row["status"].ToString().ToLower() == "overdue")
                    {
                        gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
                        gridRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        gridRow.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                        gridRow.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        gridRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        gridRow.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
                        gridRow.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading active loans:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Tag != null)
            {
                _selectedRecordId = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (_selectedRecordId < 0)
            {
                MessageBox.Show("Please select a borrow record to return.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Mark this book as returned?",
                "Confirm Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            try
            {
                // Preserve whatever amount_paid is currently on the record.
                DataTable current = DBHelper.ExecuteQuery(
                    "SELECT amount_paid FROM borrow_records WHERE record_id = @rid;",
                    new MySql.Data.MySqlClient.MySqlParameter("@rid", _selectedRecordId));

                decimal amountPaid = current.Rows.Count > 0 && current.Rows[0]["amount_paid"] != DBNull.Value
                    ? Convert.ToDecimal(current.Rows[0]["amount_paid"])
                    : 0m;

                DBHelper.ReturnBook(_selectedRecordId, amountPaid);

                MessageBox.Show("Book returned successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedRecordId = -1;
                LoadActiveLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing return:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}