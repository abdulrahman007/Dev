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
        static DatabaseProviderFactory factory;
        static Database database;



        static DbHelper()
        {
            factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory);
            database = factory.Create(DatabaseConstants.DatabaseConnectionString);
            
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

        public static int Select(DbCommand dbcommand)
        {
            return database.ExecuteNonQuery(dbcommand);
        }

        public static int Select(CommandType commandType, string Commandtext)
        {
            return database.ExecuteNonQuery(commandType, Commandtext);
        }

        public static int Select(DbCommand dbCommand, DbTransaction dbTransaction)
        {
            return database.ExecuteNonQuery(dbCommand, dbTransaction);
        }

        public static int Select(string storedProcedureName, params object[] parametersValues)
        {
            return database.ExecuteNonQuery(storedProcedureName, parametersValues);
        }

        public static int Select(DbTransaction dbTransaction, CommandType commandType, string commandText)
        {
            return database.ExecuteNonQuery(dbTransaction, commandType, commandText);
        }

        public static int Select(DbTransaction dbTransaction, string storedProcedureName, params object[] parametersValues)
        {
            return database.ExecuteNonQuery(dbTransaction, storedProcedureName, parametersValues);
        }

    }
}
