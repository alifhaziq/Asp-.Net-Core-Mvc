using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Diagnostics;
using System.Reflection;
using WebRedis2.Models;

namespace WebRedis2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IDatabase _redisDb;
        private readonly IConnectionMultiplexer _redisConnection;
        public HomeController(ILogger<HomeController> logger, IConnectionMultiplexer connection)
        {
            //_redisDb = _redisConnection.GetDatabase();
            _redisConnection = connection;
            _logger = logger;
        }

        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Personal model)
        {
            _redisConnection.GetDatabase().StringSet("user:personal", JsonConvert.SerializeObject(model));
            return RedirectToAction("App2");
        }

        public IActionResult Corprate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Corprate(Corprate model)
        {
            _redisConnection.GetDatabase().StringSet("user:corprate", JsonConvert.SerializeObject(model));
            return RedirectToAction("App2");
        }

        public IActionResult App2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult App2(Application2 model)
        {
            _redisConnection.GetDatabase().StringSet("user:application2", JsonConvert.SerializeObject(model));
            return RedirectToAction("App3");
        }

        public IActionResult App3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult App3(Application3 model)
        {
            _redisConnection.GetDatabase().StringSet("user:application3", JsonConvert.SerializeObject(model));
            return RedirectToAction("App3");
        }

        public IActionResult FinalStep()
        {
            var model = JsonConvert.DeserializeObject<Personal>(_redisConnection.GetDatabase().StringGet("user:personal"));
            var step2Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application2"));
            var step3Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application3"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
