using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Borrowing_System
{
    public static class DBHelper
    {
        private static readonly string connectionString =
             "Server=equipment-borrowing-and-return-system-jonhcarl43-a598.l.aivencloud.com;" +
             "Port=28924;" +
             "Database=lendabook;" +    
             "Uid=avnadmin;" +
             "Pwd=AVNS_1lcS9H2GAdRsmTBiB2Y;" +
             "SslMode=Required;" +
             "SslCa=ca.pem;" +
             "ConnectionTimeout=30;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] prms)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] prms)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(string sql, params MySqlParameter[] prms)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteScalar();
            }
        }
        public static DataTable ExecuteStoredProcedure(string procedureName,
                                                        params MySqlParameter[] prms)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prms != null) cmd.Parameters.AddRange(prms);
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }
        public static void ExecuteStoredProcedureNonQuery(string procedureName,
                                                          params MySqlParameter[] prms)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prms != null) cmd.Parameters.AddRange(prms);
                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetAllBooks()
            => ExecuteQuery("SELECT book_id, title, author, available FROM books ORDER BY title;");

        public static DataTable GetAvailableBooks()
            => ExecuteQuery(
               "SELECT book_id, title, author FROM books WHERE available > 0 ORDER BY title;");

        public static void AddBook(string title, string author, string isbn,
                                   int totalCopies)
            => ExecuteNonQuery(
               "INSERT INTO books(title,author,isbn,total_copies,available) " +
               "VALUES(@t,@a,@i,@tc,@tc);",
               new MySqlParameter("@t", title),
               new MySqlParameter("@a", author),
               new MySqlParameter("@i", isbn),
               new MySqlParameter("@tc", totalCopies));

        public static void UpdateBook(int bookId, string title, string author, string isbn)
            => ExecuteNonQuery(
               "UPDATE books SET title=@t, author=@a, isbn=@i WHERE book_id=@id;",
               new MySqlParameter("@t", title),
               new MySqlParameter("@a", author),
               new MySqlParameter("@i", isbn),
               new MySqlParameter("@id", bookId));

        public static void DeleteBook(int bookId)
            => ExecuteNonQuery(
               "DELETE FROM books WHERE book_id=@id;",
               new MySqlParameter("@id", bookId));
        public static DataTable GetAllBorrowers()
            => ExecuteQuery(
               "SELECT borrower_id, school_id, full_name, program, contact_no " +
               "FROM borrowers ORDER BY full_name;");

        public static DataTable GetBorrowerBySchoolId(string schoolId)
            => ExecuteQuery(
               "SELECT * FROM borrowers WHERE school_id = @sid;",
               new MySqlParameter("@sid", schoolId));

        public static void AddBorrower(string schoolId, string fullName,
                                       string program, string contactNo)
            => ExecuteStoredProcedureNonQuery("sp_add_borrower",
               new MySqlParameter("p_school_id", schoolId),
               new MySqlParameter("p_full_name", fullName),
               new MySqlParameter("p_program", program),
               new MySqlParameter("p_contact", contactNo));

        public static void UpdateBorrower(int borrowerId, string fullName,
                                          string program, string contactNo)
            => ExecuteNonQuery(
               "UPDATE borrowers SET full_name=@fn, program=@pr, contact_no=@cn " +
               "WHERE borrower_id=@id;",
               new MySqlParameter("@fn", fullName),
               new MySqlParameter("@pr", program),
               new MySqlParameter("@cn", contactNo),
               new MySqlParameter("@id", borrowerId));

        public static void DeleteBorrower(int borrowerId)
            => ExecuteNonQuery(
               "DELETE FROM borrowers WHERE borrower_id=@id;",
               new MySqlParameter("@id", borrowerId));
        public static DataTable GetAllBorrowRecords()
            => ExecuteQuery("SELECT * FROM v_borrow_details;");

        public static DataTable GetActiveBorrowRecords()
            => ExecuteQuery(
               "SELECT * FROM v_borrow_details WHERE status IN ('borrowed','overdue');");
        public static DataTable SearchBorrowRecords(string keyword)
            => ExecuteQuery(
               "SELECT * FROM v_borrow_details " +
               "WHERE school_id LIKE @kw OR full_name LIKE @kw OR book_title LIKE @kw;",
               new MySqlParameter("@kw", $"%{keyword}%"));
        public static void BorrowBook(string schoolId, string fullName, string program,
                                       string contactNo, string bookTitle,
                                       DateTime dateBorrowed, DateTime dueDate,
                                       decimal amountPaid)
            => ExecuteStoredProcedureNonQuery("sp_borrow_book",
               new MySqlParameter("p_school_id", schoolId),
               new MySqlParameter("p_full_name", fullName),
               new MySqlParameter("p_program", program),
               new MySqlParameter("p_contact", contactNo),
               new MySqlParameter("p_book_title", bookTitle),
               new MySqlParameter("p_date_borrowed", dateBorrowed.ToString("yyyy-MM-dd")),
               new MySqlParameter("p_due_date", dueDate.ToString("yyyy-MM-dd")),
               new MySqlParameter("p_amount_paid", amountPaid));
        public static void ReturnBook(int recordId, decimal amountPaid)
            => ExecuteStoredProcedureNonQuery("sp_return_book",
               new MySqlParameter("p_record_id", recordId),
               new MySqlParameter("p_amount_paid", amountPaid));
        public static void ModifyRecord(int recordId, string schoolId, string fullName,
                                         string program, string contactNo, string bookTitle,
                                         DateTime dateBorrowed, decimal amountPaid)
            => ExecuteStoredProcedureNonQuery("sp_modify_record",
               new MySqlParameter("p_record_id", recordId),
               new MySqlParameter("p_school_id", schoolId),
               new MySqlParameter("p_full_name", fullName),
               new MySqlParameter("p_program", program),
               new MySqlParameter("p_contact", contactNo),
               new MySqlParameter("p_book_title", bookTitle),
               new MySqlParameter("p_date_borrowed", dateBorrowed.ToString("yyyy-MM-dd")),
               new MySqlParameter("p_amount_paid", amountPaid));
        public static void DeleteRecord(int recordId)
            => ExecuteStoredProcedureNonQuery("sp_delete_record",
               new MySqlParameter("p_record_id", recordId));
        public static DataRow GetDashboardStats()
        {
            var dt = ExecuteStoredProcedure("sp_get_dashboard_stats");
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        public static void RefreshOverdueStatus()
            => ExecuteStoredProcedureNonQuery("sp_refresh_overdue");
    }
}