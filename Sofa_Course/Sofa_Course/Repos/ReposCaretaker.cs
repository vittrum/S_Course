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
            //MessageBox.Show("I'm working");
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
                    //MessageBox.Show($"{linens.Id} {linens.IdStud} {linens.GrantDate} {linens.RevokeDate}");
                    linenses.Add(linens);
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
                string QueryString = "update linens set grant_date = current_date, revoke_date = null, student_id = @sid where id = @lid;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@sid", Convert.ToInt32(student_id));
                Command.Parameters.AddWithValue("@lid", Convert.ToInt32(linens_id));
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
                Command.Parameters.AddWithValue("@sid", Convert.ToInt32(student_id));
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

        internal List<string> GetFreeLinens()
        {
            List<string> free_linens = new List<string>();
            //MessageBox.Show("I'm working");
            try
            {
                string QueryString =
                    "select id from linens where (grant_date is null and revoke_date is null) " +
                    "or revoke_date is not null;";
                NpgsqlCommand Command = new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    free_linens.Add(dbDataRecord["id"].ToString());
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return free_linens;
        }
    }
}
