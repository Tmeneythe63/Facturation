using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
    public class Connection
    {
      public  static SqlCeConnection getConnection()
        {
            return new SqlCeConnection(@"Data Source=C:\\Users\\Soumae\\Documents\\Visual Studio 2015\\Projects\\Facturation\\Facturation.sdf");
        }
    }
}
