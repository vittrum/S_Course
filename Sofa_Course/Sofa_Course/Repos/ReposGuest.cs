using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Repos {
    class ReposGuest {
        private Connection sqlConnection;
        public ReposGuest(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }
    }
}
