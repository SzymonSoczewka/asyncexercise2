using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("numbers")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{count}")]
        public IEnumerable<int> GetNumbers(int count)
        {
            IEnumerable<int> result = GetEvenNumbersByAmount(count);
            Thread.Sleep(2000);
            return result;
        }

        private IEnumerable<int> GetEvenNumbersByAmount(int amountNeeded)
        {
            List<int> result = new List<int>();
            int c = 0;
            while (result.Count < amountNeeded)
            {
                result.Add(c);
                c += 2;
            }
            return result;
        }

    }
}
