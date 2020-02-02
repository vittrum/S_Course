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
    class ReposRepair {
        private Connection sqlConnection;
        public ReposRepair(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public List<Repairs> GetRepairs() {
            Repairs repairs;
            List<Repairs> repairses = new List<Repairs>();
            try {
                string QueryString =
                    "select * from reguest";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    repairs = new Repairs(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["id_student_room"].ToString(),
                        dbDataRecord["description"].ToString(),
                        dbDataRecord["application_date"].ToString(),
                        dbDataRecord["date_of_completion"].ToString());
                    repairses.Add(repairs);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return repairses;
        }
        public List<Repairs> GetRepairsById(string id) {
            Repairs repairs;
            List<Repairs> repairses = new List<Repairs>();
            try {
                string QueryString =
                    "select r.id, r.id_student_room, r.description, r.date_of_completion from reguest as r, student_room as sr " +
                    "where sr.id_student = "+id+" and sr.id_room = r.id_student_room " +
                    "and r.date_of_completion is null;";
               // MessageBox.Show("Work in rep");
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    repairs = new Repairs(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["id_student_room"].ToString(),
                        dbDataRecord["description"].ToString()
                        //dbDataRecord["application_date"].ToString(),
                        /*dbDataRecord["date_of_completion"].ToString()*/);
                    repairses.Add(repairs);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return repairses;
        }
        public void CreateRequest(string id, string text) {
            try {
                string QueryString = "select create_request(@id, @text);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Command.Parameters.AddWithValue("@text", text);

                try {
                    Command.ExecuteNonQuery();
                }
                catch (Exception e) {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }
            }
            catch (Exception e) {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
        public void Confirm_request(string id, string date) {
            try {
                string QueryString = 
                    "update reguest " +
                    "set date_of_completion = '"+date+"' "+
                    "where id = @id;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                try {
                    Command.ExecuteNonQuery();
                }
                catch (Exception e) {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }
            }
            catch (Exception e) {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
    }
}
