using System;
using System.Application.Main.Services.TestModule;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiFuxion.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private ITestService _testService;
        private IMapper _mapper;
        private int correlativo = 0;

        public TestController(ITestService testService,
                              IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTest()
        {
            Thread hilo = null;
            for (int i = 0; i < 100; i++)
            {

                hilo = new Thread(
                    () => CorrerProceso(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
                    );

                hilo.Start();

            }

            return Ok("Ok");
        }

        private async void CorrerProceso(string time)
        {
            //Llamada al servicio
            try
            {
                var agrupacionResult = await _testService.ObtenerTest();
                correlativo++;
            }
            catch (Exception ex)
            {
                Log.Error(ex.StackTrace);   
            }

            string name = correlativo.ToString() + "_" + DateTime.Now.ToString("HH_mm_ss_fff").ToString();
            Log.Information(name);


            Directory.CreateDirectory(@"D:\LogServicio\" + name);

        }

    }
}