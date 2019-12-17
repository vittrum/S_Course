using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Sofa_Course.Repos;

namespace Sofa_Course {
    class Factory {
        public NpgsqlConnection NpgsqlConnection;
        public Connection SqlConnection;

        public Login log { private get; set; }
        public Login login => log;
        
        

        private bool Disposed = false;

        public Factory(string server, string port, string user, string pass, string dbname) {
            string ConnectionString = "Server=" + server + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + dbname + ";";
            NpgsqlConnection = new NpgsqlConnection(ConnectionString);
            Connection = new Connection(NpgsqlConnection);
            OpenConnection();
            RepositoryBusiness_Trip = new RepositoryBusiness_Trip(SqlConnection);
            
        }

        public void OpenConnection() {
            SqlConnection.connection.Open();
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing) {
            if (!Disposed) {
                if (disposing) {
                    SqlConnection.connection.Close();
                }
                Disposed = true;
            }
        }
        ~Factory() {
            Dispose(false);
        }
    }
}
