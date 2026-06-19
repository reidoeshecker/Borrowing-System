using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Borrowing_System
{
    public partial class Borrow : Form
    {
        private ModifyPopup _mdPopup;

        private int _selectedRecordId = -1;

        public Borrow()
        {
            InitializeComponent();
        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadBorrowRecords();
            WireConfirmButton();

            poisonDateTime1.Value = DateTime.Today;
        }
        private void LoadBooks()
        {
            try
            {
                DataTable dt = DBHelper.GetAvailableBooks();
                aloneComboBox1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                    aloneComboBox1.Items.Add(row["title"].ToString());

                if (aloneComboBox1.Items.Count > 0)
                    aloneComboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load books:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBorrowRecords()
        {
            try
            {
                DataTable dt = DBHelper.GetAllBorrowRecords();
                BindGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load records:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(DataTable dt)
        {
            dataGridView1.Rows.Clear();

            int rowNum = 1;
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    rowNum++,
                    row["school_id"],
                    row["full_name"],
                    row["program"],
                    row["contact_no"],
                    row["book_title"],
                    row["date_borrowed"] is DBNull ? "" : Convert.ToDateTime(row["date_borrowed"]).ToString("MM/dd/yyyy"),
                    row["due_date"]      is DBNull ? "" : Convert.ToDateTime(row["due_date"]).ToString("MM/dd/yyyy"),
                    row["amount_paid"]
                );
                string status = row["status"].ToString();
                if (status == "overdue")
                    dataGridView1.Rows[rowNum - 2].DefaultCellStyle.ForeColor = Color.Red;
                else if (status == "returned")
                    dataGridView1.Rows[rowNum - 2].DefaultCellStyle.ForeColor = Color.Gray;
                dataGridView1.Rows[rowNum - 2].Tag = row["record_id"];
            }
        }
        private void WireConfirmButton()
        {
            customButton1.Click -= customButton1_Click;   
            customButton1.Click += customButton1_Click;
        }
        private void customButton1_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(smallTextBox1.Text))
            { ShowWarn("Please enter the borrower's Full Name."); return; }

            if (string.IsNullOrWhiteSpace(smallTextBox2.Text))
            { ShowWarn("Please enter the Program/Section."); return; }

            if (!maskedTextBox2.MaskCompleted)
            { ShowWarn("Please enter a valid Student/Faculty ID (e.g. 2024-00001-MN-1)."); return; }

            if (!maskedTextBox1.MaskCompleted)
            { ShowWarn("Please enter a valid Contact No. (e.g. 0912-345-6789)."); return; }

            if (aloneComboBox1.SelectedIndex < 0)
            { ShowWarn("Please select a Book Title."); return; }

            try
            {
                DateTime dateBorrowed = poisonDateTime1.Value.Date;
                DateTime dueDate      = dateBorrowed.AddDays(7);  
                decimal  amtPaid      = 0;

                if (!string.IsNullOrWhiteSpace(smallTextBox3.Text))
                    decimal.TryParse(smallTextBox3.Text, out amtPaid);

                DBHelper.BorrowBook(
                    maskedTextBox2.Text.Trim(),
                    smallTextBox1.Text.Trim(),
                    smallTextBox2.Text.Trim(),
                    maskedTextBox1.Text.Trim(),
                    aloneComboBox1.SelectedItem.ToString(),
                    dateBorrowed,
                    dueDate,
                    amtPaid
                );

                MessageBox.Show("Book borrowed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadBooks();
                LoadBorrowRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to borrow book:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SearchRecords(string keyword)
        {
            try
            {
                DataTable dt = string.IsNullOrWhiteSpace(keyword)
                    ? DBHelper.GetAllBorrowRecords()
                    : DBHelper.SearchBorrowRecords(keyword);
                BindGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void customButton2_Click(object sender, EventArgs e)
        {
            if (_selectedRecordId < 0)
            {
                ShowWarn("Please select a record to modify.");
                return;
            }

            if (_mdPopup == null || _mdPopup.IsDisposed)
            {
                _mdPopup = new ModifyPopup(_selectedRecordId);
                _mdPopup.FormClosed += (s, args) =>
                {
                    _mdPopup = null;
                    LoadBooks();
                    LoadBorrowRecords();  
                };
                _mdPopup.Show(this);
            }
            else
            {
                _mdPopup.BringToFront();
                _mdPopup.Focus();
            }
        }
        public void DeleteSelectedRecord()
        {
            if (_selectedRecordId < 0)
            {
                ShowWarn("Please select a record to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this borrow record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DBHelper.DeleteRecord(_selectedRecordId);
                _selectedRecordId = -1;
                LoadBooks();
                LoadBorrowRecords();
                MessageBox.Show("Record deleted.", "Done",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            if (row.Tag != null)
                _selectedRecordId = Convert.ToInt32(row.Tag);
        }
        private void ClearForm()
        {
            smallTextBox1.Text  = "";
            smallTextBox2.Text  = "";
            smallTextBox3.Text  = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            poisonDateTime1.Value = DateTime.Today;
            if (aloneComboBox1.Items.Count > 0)
                aloneComboBox1.SelectedIndex = 0;
        }

        private static void ShowWarn(string msg)
            => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void label1_Click(object sender, EventArgs e) { }
        private void roundedPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}