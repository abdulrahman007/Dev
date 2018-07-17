using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace Database_Logic
{
    public class DbHelper
    {
        static DatabaseProviderFactory factory;
        static Database database;

        //public static DbCommand Command { get; private set; }

        static DbHelper()
        {
            factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory);
            database = factory.Create(DatabaseConstants.DatabaseConnectionString);

        }

        public static DbCommand FillCommand()
        {
            DbConnection dbConnection = database.CreateConnection();
            DbCommand command = dbConnection.CreateCommand();
            return command;
        }

        public static DbCommand FillCommand(DbTransaction transaction)
        {
            DbCommand command = transaction.Connection.CreateCommand();
            command.Transaction = transaction;
            return command;
        }

        public static DbTransaction VTransaction()
        {
            DbConnection conn = database.CreateConnection();
            DbCommand command = conn.CreateCommand();
            conn.Open();
            DbTransaction transaction = conn.BeginTransaction();
            return transaction;
        }


        public static void CreateParameter(ref DbCommand dbCommand, DbType ptype, ParameterDirection pdirection,string pargumentName, object pValue)
        {
            DbParameter parameter;

            parameter = dbCommand.CreateParameter();
            parameter.DbType = ptype;
            parameter.Direction = pdirection;
            parameter.ParameterName = pargumentName;
            parameter.Value = pValue;

            dbCommand.Parameters.Add(parameter);
            
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
