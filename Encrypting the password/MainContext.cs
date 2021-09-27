using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypting_the_password
{
    class MainContext
    {
        private string connectionString = "Server=MIKHAIL;Database=master;Trusted_Connection=True;";   

        public string ConnectionString 
        {
            get { return connectionString; }
        }
    }
}
