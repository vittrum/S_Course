using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Sofa_Course.Tables;
using System.Data.Common;

namespace Sofa_Course.Repos
{
    class ReposWatchman
    {
        private Connection sqlConnection;
        public ReposWatchman(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Student> PassStudent(string name, string lastname) {
            Student student;
            List<Student> students = new List<Student>();
            try {
                string QueryString ="select * from students where name = @name and lastname = @lastname;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@lastname", lastname);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    student = new Student(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["lastname"].ToString(),
                        dbDataRecord["father_name"].ToString(),
                        dbDataRecord["course"].ToString(),
                        dbDataRecord["specialty"].ToString());
                    students.Add(student);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return students;
        }
        public void PassGuest(string name, string lastname, string father_name, string adress, int room_id)
        {
            try
            {
                string QueryString = "insert into guests(name, lastname, father_name, " +
                    "registration_adress, visit_date, arrival_time, room_id) " +
                    "values(@name, @lastname, @father_name, @adress, current_date, localtime, @room_id);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@lastname", lastname);
                Command.Parameters.AddWithValue("@father_name", father_name);
                Command.Parameters.AddWithValue("@adress", adress);
                Command.Parameters.AddWithValue("@room_id", room_id);
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
        }
    }
}
