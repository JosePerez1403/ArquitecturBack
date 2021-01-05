using AutoMapper;
using System;
using System.Application.Main.Dtos.Test;
using System.Collections.Generic;
using System.Domain.Interfaces.TestModule.Aggregates.TestAgg;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Main.Services.TestModule
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private IMapper _mapper;

        public TestService(ITestRepository testRepository, 
                           IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestDto>> ObtenerTest()
        {
            IEnumerable<TestDto> TestDto = null;

            try
            {
                var testResult = await _testRepository.ObtenerTest();
                TestDto = _mapper.Map<IEnumerable<TestDto>>(testResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return TestDto;

        }
    }
}
