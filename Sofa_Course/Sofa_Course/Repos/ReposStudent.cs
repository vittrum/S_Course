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
    class ReposStudent {
        private Connection sqlConnection;
        public ReposStudent (Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public void Settle_Student (
            string name, 
            string surname, 
            string patronymic, 
            string id, 
            string id_pay, 
            string sanitar, 
            string id_room,
            string fac, 
            string spec, 
            string priv, 
            string set_date) {
            try {
                //MessageBox.Show(priv);
                string QueryString = "select settle_student" +
                    "(@id, @name, @surname, @patr, @fac, @spec, @id_pay, '" +sanitar+ 
                    "', @id_priv, @id_room, '"+ set_date +"');";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@surname", surname);
                Command.Parameters.AddWithValue("@patr", patronymic);
                Command.Parameters.AddWithValue("@fac", fac);
                Command.Parameters.AddWithValue("@date", set_date);
                Command.Parameters.AddWithValue("@spec", spec);
                Command.Parameters.AddWithValue("@id_pay", Convert.ToInt32(id_pay));
                Command.Parameters.AddWithValue("@sanitar", sanitar);
                Command.Parameters.AddWithValue("@id_room", Convert.ToInt32(id_room));
                Command.Parameters.AddWithValue("@id_priv", Convert.ToInt32(priv));
                
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

        public void Kick_Student (string id) {
            try {
                string QueryString =
                    "delete from student_room where id_student = @id;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка выполнения операции. \n Проверьте корректность введенных данных" + ex.Message);
            }
        }

        public List<Student> Get_Student_By_Pass (string id) {
            Student student;
            List<Student> students = new List<Student>();

            try {
                string QueryString =
                    "select * from student where id = @id";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    student = new Student(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["surname"].ToString(),
                        dbDataRecord["patronymic"].ToString(),
                        dbDataRecord["faculty"].ToString(),
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

        public List<Student> Get_Student_By_Name(string name, string surname) {
            Student student;
            List<Student> students = new List<Student>();
            try {
                string QueryString =
                    "select * from student where name like '" + name + "%' " +
                    "and surname like '" + surname + "%';";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                //Command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    student = new Student(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["surname"].ToString(),
                        dbDataRecord["patronymic"].ToString(),
                        dbDataRecord["faculty"].ToString(),
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
    }
}
