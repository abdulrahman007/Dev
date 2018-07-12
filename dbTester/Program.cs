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
             
            System.Data.Common.DbCommand dbcommand;
            System.Data.Common.DbParameter parameter;

            dbcommand = DbHelper.FillCommand();



            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_activitytypeid", 1);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.String, System.Data.ParameterDirection.Input, "p_description", "How Are You?");
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_created", 21);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Output, "p_logid", DBNull.Value);
            

            dbcommand.CommandText = "Pkg_Activitylog.sp_Insert";
            dbcommand.CommandType = System.Data.CommandType.StoredProcedure;



           
           DbHelper.Execute(dbcommand);

        }
    }
}
