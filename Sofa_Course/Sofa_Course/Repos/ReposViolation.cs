using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Sofa_Course.Repos
{
    class ReposViolation
    {
        private Connection sqlConnection;
        public ReposViolation(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public void CreateReport(string stud_id, string text, string date, string fact = "нарушение")
        {
            try
            {
                string QueryString = "select create_violation('" + date + "', @id_stud, @text,@fact);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@text", text);
                Command.Parameters.AddWithValue("@fact", fact);
                Command.Parameters.AddWithValue("@id_stud", Convert.ToInt32(stud_id));
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
