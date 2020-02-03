using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Sofa_Course.Tables;
using System.Data.Common;

namespace Sofa_Course.Repos {
    class ReposReport {
        private Connection sqlConnection;
        public ReposReport(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }
        /*public List<Report> GetViolation() {
            Report report;
            List<Report> reports = new List<Report>();
            try {
                string QueryString =
                    "select * from violations";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    report = new Report(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["date_violation"].ToString(),
                        dbDataRecord["date_of_issue"].ToString());
                    reports.Add(report);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return linenses;
        }*/
        public void CreateReport(string stud_id, string text, string date) {
            try {
                string QueryString = "select create_violation('"+date+"', 'нарушение', @id_stud, @text);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                //Command.Parameters.AddWithValue("@date", date);
                Command.Parameters.AddWithValue("@text", text);
                Command.Parameters.AddWithValue("@id_stud", Convert.ToInt32(stud_id));
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

        public void SetPenalty (string id_pen, string type) {

            try {
                string QueryString =
                    "update violation set type_work_out = @type where id = @id_pen;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id_pen));
                Command.Parameters.AddWithValue("@type", type);
                Command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка выполнения операции. \n Проверьте корректность введенных данных" + ex.Message);
            }
        }
    }
}
