using System;
using System.Collections.Generic;
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
        public List<Student> PassStudent(string gname, string lastname) {
            Student student;
            List<Student> students = new List<Student>();
            try {
                string QueryString ="select * from students where id = id ";
                if (gname != "")
                {
                    QueryString += " and name = @name";
                }
                if (lastname != "")
                {
                    QueryString += " and lastname = @lastname";
                }
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@name", gname);
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
        public void PassGuest(string gname, string lastname, string father_name, string adress, int stid)
        {
            try
            {
                MessageBox.Show(gname);
                MessageBox.Show("");
                string QueryString = "insert into guests(gname, lastname, father_name, registration_adress, visit_date, arrival_time, room_id)" +
                    " values (@gname, @lastname, @father_name, @adress, current_date, localtime, " +
                    "(select id from room_student where student_id = @stid));";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                // NpgsqlDataReader dataReader = Command.ExecuteReader();
                Command.Parameters.AddWithValue("@gname", gname);
                Command.Parameters.AddWithValue("@lastname", lastname);
                Command.Parameters.AddWithValue("@father_name", father_name);
                Command.Parameters.AddWithValue("@adress", adress);
                Command.Parameters.AddWithValue("@stid", Convert.ToInt32(stid));
                try
                {
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Guest passed");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных" + e.ToString());
                }

            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + ex.Message);
            }
            
        }
    }
}
