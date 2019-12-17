using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Sofa_Course.Repos {
    class ReposStudent {
        private Connection sqlConnection;
        public ReposStudent (Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public void Settle_Student (string name, string surname, 
            string patronymic, string id, string id_pay, string sanitar, string id_room,
            string fac, string spec, string priv, string set_date) {
            try {
                string QueryString = "select settle_student" +
                    "(@id, @name, @surname, @patr, @fac, @spec, @id_pay" +
                    "@sanitar, @id_priv, @id_room, @date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@surname", surname);
                Command.Parameters.AddWithValue("@patr", patronymic);
                Command.Parameters.AddWithValue("@fac", fac);
                Command.Parameters.AddWithValue("@date", set_date);
                Command.Parameters.AddWithValue("@spec", spec);
                Command.Parameters.AddWithValue("@id_pay", Convert.ToInt32(id_pay));
                Command.Parameters.AddWithValue("@sanitar", sanitar);
                Command.Parameters.AddWithValue("@id_room", Convert.ToInt32(id_room));
                Command.Parameters.AddWithValue("@priv", Convert.ToInt32(priv));
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
