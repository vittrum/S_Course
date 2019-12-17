using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Repos {
    class ReposRepair {
        private Connection sqlConnection;
        public ReposRepair(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }
    }
}
