using System;
using System.Collections.Generic;
using System.Domain.Entities.TestModule;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.TestModule.Aggregates.TestAgg
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestEntity>> ObtenerTest();
    }
}
