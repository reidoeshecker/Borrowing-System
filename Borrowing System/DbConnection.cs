using MySql.Data.MySqlClient;
using System;
using System.Data;

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
             "ConnectionTimeout=30;" +
             "ConnectionReset=true;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
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
            => ExecuteStoredProcedure("sp_get_all_books");

        public static DataTable GetAvailableBooks()
            => ExecuteStoredProcedure("sp_get_available_books");


        public static void AddBorrower(string schoolId, string fullName,
                                       string program, string contactNo)
            => ExecuteStoredProcedureNonQuery("sp_add_borrower",
               new MySqlParameter("p_school_id", schoolId),
               new MySqlParameter("p_full_name", fullName),
               new MySqlParameter("p_program", program),
               new MySqlParameter("p_contact", contactNo));

        public static DataTable GetAllBorrowRecords()
            => ExecuteStoredProcedure("sp_get_all_borrow_records");

        public static DataTable GetActiveBorrowRecords()
            => ExecuteStoredProcedure("sp_get_active_borrow_records");

        public static DataTable SearchBorrowRecords(string keyword)
            => ExecuteStoredProcedure("sp_search_borrow_records",
               new MySqlParameter("p_keyword", keyword));

        public static DataTable GetBorrowRecordById(int recordId)
            => ExecuteStoredProcedure("sp_get_borrow_record_by_id",
               new MySqlParameter("p_record_id", recordId));

        public static DataTable GetRecordAmountPaid(int recordId)
            => ExecuteStoredProcedure("sp_get_record_amount_paid",
               new MySqlParameter("p_record_id", recordId));
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