using System;
using System.Collections.Generic;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;
using Sofa_Course.Tables;

namespace Sofa_Course.Repos
{
    class ReposStudent
    {
        private Connection sqlConnection;
        public ReposStudent(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        internal List<Student> GetStudentByFilters(string course, string specialty)
        {
            //MessageBox.Show(course + ' ' + specialty);
            Student student;
            List<Student> students = new List<Student>();
            try
            {
                string QueryString = "select * from students where id = id";
                if (course != "")
                {
                    QueryString += " and course = " + course;
                }
                if (specialty != "")
                {
                    QueryString += " and specialty = '" + specialty+"'";
                }
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
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
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return students;
        }

        internal void CreateRepairRequest(string stud_id, string repair_text, string type)
        {
            try
            {
                string QueryString = "select create_repair_request(@sid, @type, @theme)";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@sid", Convert.ToInt32(stud_id));
                Command.Parameters.AddWithValue("@type", type);
                Command.Parameters.AddWithValue("@theme", repair_text);
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

        internal void ConfirmRepairs(string repair_id)
        {
            MessageBox.Show(repair_id);
            try
            {
                string QueryString = "update repair_request set repair_date = current_date where id = @rid;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@rid", Convert.ToInt32(repair_id));
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

        internal List<Repairs> ShowStudentsRequest(string stud_id)
        {
            Repairs repair_request;
            List<Repairs> repair_requests = new List<Repairs>();
            try
            {
                string QueryString = "select * from students_requests where student_id = @sid and repair_date is null;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                Command.Parameters.AddWithValue("@sid", Convert.ToInt32(stud_id));
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    repair_request = new Repairs(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["type"].ToString(),
                        dbDataRecord["theme"].ToString(),
                        dbDataRecord["request_date"].ToString(),
                        dbDataRecord["student_id"].ToString());
                    repair_requests.Add(repair_request);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return repair_requests;
        }
    }
}
