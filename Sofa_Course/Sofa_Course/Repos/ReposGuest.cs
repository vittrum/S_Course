using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sofa_Course.Tables;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;

namespace Sofa_Course.Repos {
    class ReposGuest {
        private Connection sqlConnection;
        public ReposGuest(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }

        /*public List<Guest> Show_Guests() {
            Guest guest;
            List<Guest> guests = new List<Guest>();
            try {
                string QueryString =
                    "select *" +
                    "from \"staff\"" +
                    "order by \"ID_Staff\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader) {
                    guest = new Guest(
                        dbDataRecord["ID_Staff"].ToString(),
                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Education"].ToString(),
                        dbDataRecord["Phone"].ToString(),
                        dbDataRecord["Registration"].ToString(),
                        dbDataRecord["Pass"].ToString());
                    guests.Add(guest);
                }
                dataReader.Close();
            }
            catch (PostgresException ex) {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return guests;
        }*/
    }
}
