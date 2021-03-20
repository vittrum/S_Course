using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Repos
{
    class ReposStaff
    {
        private Connection sqlConnection;
        public ReposStaff(Connection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
    }
}
