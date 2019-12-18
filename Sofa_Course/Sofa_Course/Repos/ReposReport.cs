using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Sofa_Course.Repos {
    class ReposReport {
        private Connection sqlConnection;
        public ReposReport(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

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
