using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using Sofa_Course.Tables;

namespace Sofa_Course.Repos {
    class ReposCaretaker {
        private Connection sqlConnection;
        public ReposCaretaker(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public List<Linens> GetLinens() {
            Linens linens;
            List<Linens> linenses = new List<Linens>();
            try {
                string QueryString =
                    "select * from linens_set";
                NpgsqlCommand Command = new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    linens = new Linens(
                        dbDataRecord["linens_num"].ToString(),
                        dbDataRecord["stundent_num"].ToString(),
                        dbDataRecord["grant_date"].ToString(),
                        dbDataRecord["revoke_date"].ToString(),                        
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["lastname"].ToString());
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return linenses;
        }
        
        internal void GiveLinens(string linens_id, string student_id)
        {
            try
            {
                string QueryString = "update linens set grant_date = current_date, student_id = @sid where id = @lid;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@sid", student_id);
                Command.Parameters.AddWithValue("@lid", linens_id);
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }

        public void ReturnLinens(string student_id) {
            try
            {
                string QueryString = "update linens set revoke_date = current_date where student_id = @sid";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@sid", student_id);
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
    }
}
