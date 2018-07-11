using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Database_Logic
{
    public class DbHelper
    {
        static Database database;

        static DbHelper()
        {
            database = DatabaseFactory.CreateDatabase(DatabaseConstants.DatabaseConnectionString);
        }

        public static int Execute(DbCommand dbCommand)
        {
            return database.ExecuteNonQuery(dbCommand);
        }

        public static int Execute()
        {
            return -1;
        }

        public static int Execute(CommandType Commandtype, string CommandText)
        {
            return database.ExecuteNonQuery(Commandtype, CommandText);
        }

        public static int Execute(DbCommand dbCommand, DbTransaction transaction)
        {
            return database.ExecuteNonQuery(dbCommand, transaction);
        }

        public static int Execute(string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        public static int Execute(DbTransaction transaction,CommandType dbCommandtype, string commandText)
        {
            return database.ExecuteNonQuery(transaction,dbCommandtype,commandText);
        }

        public static int Execute(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteNonQuery(transaction,storedProcedureName, parameterValues);
        }

        
    }
}
