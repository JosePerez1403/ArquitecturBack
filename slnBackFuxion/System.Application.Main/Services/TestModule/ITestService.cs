using System;
using System.Application.Main.Dtos.Test;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Main.Services.TestModule
{
    public interface ITestService
    {
        Task<IEnumerable<TestDto>> ObtenerTest();
    }
}
