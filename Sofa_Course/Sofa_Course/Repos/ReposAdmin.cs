using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Sofa_Course.Repos
{
    class ReposAdmin
    {
        private Connection sqlConnection;
        public ReposAdmin(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public void SettleStudent(
            string name, 
            string lastname,
            string father_name,
            int course, 
            string specialty,
            string invoice, 
            string sanpass,
            int category,
            int room)
        {
            try
            {
                string QueryString = "select settle_student(@name, @lastname, @father_name, @course, @specialty," +
                    "@invoice, @sanpass, @category, @room);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@lastname", lastname);
                Command.Parameters.AddWithValue("@father_name", father_name);
                Command.Parameters.AddWithValue("@course", course);
                Command.Parameters.AddWithValue("@specialty", specialty);
                Command.Parameters.AddWithValue("@invoice", invoice);
                Command.Parameters.AddWithValue("@sanpass", sanpass);
                Command.Parameters.AddWithValue("@room", room);
                Command.Parameters.AddWithValue("@category", category);
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
        public void KickStudent(int room_student_id)
        {
            try
            {
                string QueryString = "update room_student set eviction_date = current_date where id = @rsid;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@rsid", room_student_id);
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
        public void SetPenalty(int violation_id, string text)
        {
            try
            {
                string QueryString = "update violations set penalty = text where id = @vid;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@vid", violation_id);
                Command.Parameters.AddWithValue("@text", text);
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
