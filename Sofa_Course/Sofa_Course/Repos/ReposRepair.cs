using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using Sofa_Course.Tables;

namespace Sofa_Course.Repos {
    class ReposRepair {
        private Connection sqlConnection;
        public ReposRepair(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        public List<Repairs> GetRepairs() {
            Repairs repairs;
            List<Repairs> repairses = new List<Repairs>();
            try {
                string QueryString =
                    "select * from reguest";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    repairs = new Repairs(
                        dbDataRecord["id"].ToString(),
                        dbDataRecord["id_student_room"].ToString(),
                        dbDataRecord["type_of_repait"].ToString(),
                        dbDataRecord["description"].ToString(),
                        dbDataRecord["application_date"].ToString(),
                        dbDataRecord["date_of_completion"].ToString());
                    repairses.Add(repairs);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return repairses;
        }

        public void CreateRequest() {

        }
    }
}
