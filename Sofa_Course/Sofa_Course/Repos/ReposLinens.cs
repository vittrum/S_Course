using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Repos {
    class ReposLinens {
        private Connection sqlConnection;
        public ReposLinens(Connection sqlConnection) {
            this.sqlConnection = sqlConnection;
        }
    }
}
