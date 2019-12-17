using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;


namespace Sofa_Course {
    class Connection {
        private static Connection NewConnection = null;
        public NpgsqlConnection connection { get; }
        public Connection(NpgsqlConnection Connection) {
            this.connection = Connection;
        }
        public Connection CreateConnection => NewConnection = new Connection(connection);
        public void OpenConnection() {
            try {
                connection.Open();
            }
            catch (Exception ex) {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        public void CloseConnection() {
            try {
                connection.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
