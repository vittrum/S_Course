using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using Sofa_Course.Tables;

namespace Sofa_Course.Repos {
    class ReposLinens {
        private Connection sqlConnection;
        public ReposLinens(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public List<Linens> GetLinens() {
            Linens linens;
            List<Linens> linenses = new List<Linens>();
            try {
                string QueryString =
                    "select * from linens_set";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    linens = new Linens(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["id_student"].ToString(),
                        dbDataRecord["date_of_issue"].ToString());
                    linenses.Add(linens);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return linenses;
        }
        public void GiveLinens(string id, string stud, string date) {
            try {
                string QueryString = "update linens_set " +
                    "set id_student = @id_stud, date_of_issue = '" + date+ 
                    "'" +
                    "where id = @id;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@date", date);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Command.Parameters.AddWithValue("@id_stud", Convert.ToInt32(stud));
                try {
                    Command.ExecuteNonQuery();
                }
                catch {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных");
                }
            }
            catch (Exception e) {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
        public void ReturnLinens(string id) {
            try {
                MessageBox.Show(id);
                string QueryString = "update linens_set " +
                    "set id_student = null, date_of_issue = null"+
                    "where id = @id;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                try {
                    Command.ExecuteNonQuery();
                }
                catch {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных");
                }
            }
            catch (Exception e) {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
    }
}
