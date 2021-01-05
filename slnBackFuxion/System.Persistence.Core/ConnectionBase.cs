using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Infrastructure.Tools.Configuration;
using Microsoft.Extensions.Configuration;

namespace System.Persistence.Core
{
    public class ConnectionBase : IConnectionBase
    {
        //Cadena de conexion
        private string strConexionSQL = null;

        //Constante de conexion
        SqlConnection DataConnectionSQL = new SqlConnection();

        //Clases imagen del appsetting.config
        private readonly AppSettings _appSettings;

        //Opciones de conexión
        public enum enuTypeDataBase
        {
            SQLFuxion
        }

        public enum enuTypeExecute
        {
            ExecuteNonQuery,
            ExecuteReader
        }

        public DbParameterCollection ParamsCollectionResult { get; set; }

        //Constructor de la clase 
        //public ConnectionBase(IOptions<AppSettings> appSettings)
        //{
        //    _appSettings = appSettings.Value;

        //    this.strConexionSQL = _appSettings.ConnectionStringSQL;
        //    DataConnectionSQL.ConnectionString = this.strConexionSQL;
        //}

        public ConnectionBase(IConfiguration Configuration)
        {
            //_appSettings = appSettings.Value;

            this.strConexionSQL = Configuration["AppSettings:ConnectionStringSQL"]; // _appSettings.ConnectionStringPostGres;
            DataConnectionSQL.ConnectionString = this.strConexionSQL;
        }

        public DbConnection ConnectionGet(enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxion)
        {
            DbConnection DataConnection = null;
            switch (typeDataBase)
            {
                case enuTypeDataBase.SQLFuxion:
                    DataConnection = DataConnectionSQL;
                    break;
                default:
                    break;
            }
            return DataConnection;
        }

        public DbDataReader ExecuteByStoredProcedure(string nameStore,
                IEnumerable<DbParameter> parameters = null,
                enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxion,
                enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
                )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                //z = ParamsCollectionResult;
                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;
        }
    }
}
