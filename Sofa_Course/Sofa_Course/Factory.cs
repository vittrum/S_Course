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

        public ReposStudent student { get; }
        public ReposGuest guest { get; }
        public ReposReport report { get; }
        public ReposLinens linens { get; }
        public ReposRepair repair { get; }
        

        private bool Disposed = false;

        public Factory(string server, string port, string user, string pass, string dbname) {
            string ConnectionString = "Server=" + server + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + dbname + ";";
            NpgsqlConnection = new NpgsqlConnection(ConnectionString);
            SqlConnection = new Connection(NpgsqlConnection);
            OpenConnection();
            guest = new ReposGuest(SqlConnection);
            student = new ReposStudent(SqlConnection);
            report = new ReposReport(SqlConnection);

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
