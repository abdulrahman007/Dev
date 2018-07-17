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
           // System.Data.Common.DbParameter parameter;
            System.Data.Common.DbTransaction transaction;

            transaction = DbHelper.VTransaction();
            dbcommand = DbHelper.FillCommand(transaction);

            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_typeid", 5);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.String, System.Data.ParameterDirection.Input, "p_desc", "Forza Juve");
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_modifiedby", 10);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_activitylogid", 45);

            dbcommand.CommandText = "Pkg_Activitylog.sp_Update";
            dbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            dbcommand.ExecuteNonQuery();
            //dbcommand = DbHelper.FillCommand(transaction);

            dbcommand.Parameters.Clear();

            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_activitytypeid", 9);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.String, System.Data.ParameterDirection.Input, "p_description", "Back in 5");
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, "p_created", 12);
            DbHelper.CreateParameter(ref dbcommand, System.Data.DbType.Int32, System.Data.ParameterDirection.Output, "p_logid", DBNull.Value);

            dbcommand.CommandText = "Pkg_Activitylog.sp_Insert";
            dbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            dbcommand.ExecuteNonQuery();
            
            transaction.Commit();

            
            //DbHelper.Execute(dbcommand);

        }
    }
}
