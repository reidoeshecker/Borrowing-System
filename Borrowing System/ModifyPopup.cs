using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Borrowing_System
{
    public partial class ModifyPopup : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeft, int nTop, int nRight, int nBottom, int nWidth, int nHeight);

        private readonly int _recordId;
        public ModifyPopup(int recordId)
        {
            InitializeComponent();
            _recordId = recordId;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void ModifyPopup_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadRecordData();
            WireSaveButton();
        }

        private void LoadBooks()
        {
            try
            {
                DataTable dt = DBHelper.GetAllBooks();
                aloneComboBox1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                    aloneComboBox1.Items.Add(row["title"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load books:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecordData()
        {
            try
            {
                DataTable dt = DBHelper.GetBorrowRecordById(_recordId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Record not found.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                smallTextBox1.Text = row["full_name"].ToString();
                smallTextBox2.Text = row["program"].ToString();
                smallTextBox3.Text = row["amount_paid"].ToString();
                maskedTextBox2.Text = row["school_id"].ToString();
                maskedTextBox1.Text = row["contact_no"].ToString();

                if (!(row["date_borrowed"] is DBNull))
                    poisonDateTime1.Value = Convert.ToDateTime(row["date_borrowed"]);

                string bookTitle = row["book_title"].ToString();
                int idx = aloneComboBox1.Items.IndexOf(bookTitle);
                // If not present (book now unavailable), add it temporarily
                if (idx < 0)
                {
                    aloneComboBox1.Items.Insert(0, bookTitle);
                    idx = 0;
                }
                aloneComboBox1.SelectedIndex = idx;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load record:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WireSaveButton()
        {
            customButton2.Click -= OnSaveChanges;
            customButton2.Click += OnSaveChanges;
        }


        private void OnSaveChanges(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(smallTextBox1.Text))
            { ShowWarn("Full Name is required."); return; }

            if (string.IsNullOrWhiteSpace(smallTextBox2.Text))
            { ShowWarn("Program/Section is required."); return; }

            if (aloneComboBox1.SelectedIndex < 0)
            { ShowWarn("Please select a Book Title."); return; }

            decimal amtPaid = 0;
            if (!string.IsNullOrWhiteSpace(smallTextBox3.Text))
                decimal.TryParse(smallTextBox3.Text, out amtPaid);

            try
            {
                DBHelper.ModifyRecord(
                    _recordId,
                    maskedTextBox2.Text.Trim(),
                    smallTextBox1.Text.Trim(),
                    smallTextBox2.Text.Trim(),
                    maskedTextBox1.Text.Trim(),
                    aloneComboBox1.SelectedItem.ToString(),
                    poisonDateTime1.Value.Date,
                    amtPaid
                );

                MessageBox.Show("Record updated successfully!", "Saved",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void customButton1_Click_1(object sender, EventArgs e)
            => this.Close();

        private void customButton3_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to permanently delete this borrow record?\n\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DBHelper.DeleteRecord(_recordId);
                MessageBox.Show("Record deleted successfully.", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowWarn(string msg)
            => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}