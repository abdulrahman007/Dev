using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Logic;

namespace dbTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //"Pkg_Activitylog.sp_Insert"

            /*
             
p_activitytypeid number,
p_description varchar,
--p_time timestamp,
p_created number,
p_logid out number
             
             */

            int activityTypeID = 1;

            string description = "Hello";

            int createdby = 1;

            int logID = 1;

            DbHelper.Execute("Pkg_Activitylog.sp_Insert", new object[] { activityTypeID,description,createdby,logID  });

        }
    }
}
