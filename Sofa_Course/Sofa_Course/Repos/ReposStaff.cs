using System;
using System.Collections.Generic;
using Sofa_Course.Tables;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;

namespace Sofa_Course.Repos
{
    class ReposStaff
    {
        private Connection sqlConnection;
        public ReposStaff(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        internal List<Repairs> GetAllRequests()
        {
            Repairs repair;
            List<Repairs> repairs = new List<Repairs>();
            try
            {
                string QueryString = "select * from repair_request";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    repair = new Repairs(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["room_student_id"].ToString(),
                        dbDataRecord["type"].ToString(),
                        dbDataRecord["theme"].ToString(),
                        dbDataRecord["request_date"].ToString(),
                        dbDataRecord["repair_date"].ToString());
                    repairs.Add(repair);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return repairs;
        }
    }
}
