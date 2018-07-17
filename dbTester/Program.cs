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
            System.Data.Common.DbTransaction transaction;

           
            dbcommand = DbHelper.FillCommand();
            transaction = DbHelper.VTransaction();


            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_activitytypeid", 4);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.String, System.Data.ParameterDirection.Input, "p_description", "I'm on ma way");
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_created", 1);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Output, "p_logid", DBNull.Value);



            transaction.Commit();

            dbcommand.CommandText = "Pkg_Activitylog.sp_Insert";
            dbcommand.CommandType = System.Data.CommandType.StoredProcedure;



           
           DbHelper.Execute(dbcommand);

        }
    }
}
