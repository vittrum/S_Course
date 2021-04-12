using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Sofa_Course.Repos;
using Sofa_Course.Auth;

namespace Sofa_Course {
    class Factory {
        public NpgsqlConnection NpgsqlConnection;
        public Connection SqlConnection;

        public ReposAdmin admin { get; }
        public ReposCaretaker caretaker { get; }
        public ReposStaff staff { get; }
        public ReposStudent student { get; }
        public ReposViolation violation { get; }
        public ReposWatchman watchman { get; }
        public Login login { get; }
        public Registration reg { get; }


        private bool Disposed = false;

        public Factory(string server, string port, string user, string pass, string dbname) {
            string ConnectionString = "Server=" + server + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + dbname + ";";
            NpgsqlConnection = new NpgsqlConnection(ConnectionString);
            SqlConnection = new Connection(NpgsqlConnection);
            OpenConnection();
            caretaker = new ReposCaretaker(SqlConnection);
            admin = new ReposAdmin(SqlConnection);
            staff = new ReposStaff(SqlConnection);
            student = new ReposStudent(SqlConnection);
            violation = new ReposViolation(SqlConnection);
            watchman = new ReposWatchman(SqlConnection);
            login = new Login(SqlConnection);
            reg = new Registration(SqlConnection);
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
