using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Domain.Entities.TestModule;
using System.Domain.Interfaces.TestModule.Aggregates.TestAgg;
using System.Infrastructure.Tools.Configuration;
using System.Infrastructure.Tools.Extensions;
using System.Persistence.Core;
using System.Text;
using System.Threading.Tasks;

namespace System.Persistence.Data.TestModule.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConnectionBase _connectionBase;

        public TestRepository(IOptions<AppSettings> appSettings,
                              IConnectionBase ConnectionBase)
        {
            this.appSettings = appSettings;
            _connectionBase = ConnectionBase;
        }

        public Task<IEnumerable<TestEntity>> ObtenerTest()
        {
            IEnumerable<TestEntity> entityTest = null;
            List<SqlParameter> parameters = new List<SqlParameter>();

            DateTime parametro1 = DateTime.Now;
            int parametro2 = 520;
            int parametro3 = 569;

            parameters.Add(new SqlParameter("@nCustomerID", parametro1));
            parameters.Add(new SqlParameter("@nPeriodInic", parametro2));
            parameters.Add(new SqlParameter("@nPeriodFinc", parametro3));

            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbFuxion.FX_ComisionDetails", parameters))
                {
                    entityTest = dr.ReadRows<TestEntity>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(entityTest);

        }
    }
}
