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
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDictionary<string, object> _sessionStorage;

        private string GetUserSessionId()
        {
            const string cookieName = "UserSessionId";
            if (!HttpContext.Request.Cookies.TryGetValue(cookieName, out var userSessionId))
            {
                userSessionId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                };
                HttpContext.Response.Cookies.Append(cookieName, userSessionId, cookieOptions);
            }
            return userSessionId;
        }

        public HomeController(ILogger<HomeController> logger, IConnectionMultiplexer connection, IDictionary<string, object> sessionStorage)
        {
            _redisConnection = connection;
            _logger = logger;
            _sessionStorage = sessionStorage;
        }

        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Personal model)
        {
            //_redisConnection.GetDatabase().StringSet("user:personal", JsonConvert.SerializeObject(model));
            var sessionId = GetUserSessionId();
            _sessionStorage[$"user:personal:{sessionId}"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("App2");
        }

        public IActionResult Corprate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Corprate(Corprate model)
        {
            //_redisConnection.GetDatabase().StringSet("user:corporate", JsonConvert.SerializeObject(model));
            var sessionId = GetUserSessionId();
            _sessionStorage[$"user:corporate:{sessionId}"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("App2");
        }

        public IActionResult App2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult App2(Application2 model)
        {
            //_redisConnection.GetDatabase().StringSet("user:application2", JsonConvert.SerializeObject(model));
            var sessionId = GetUserSessionId();
            _sessionStorage[$"user:application2:{sessionId}"] = JsonConvert.SerializeObject(model);
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
            return RedirectToAction();
        }

        public IActionResult FinalStep()
        {
            //var model = JsonConvert.DeserializeObject<Personal>(_redisConnection.GetDatabase().StringGet("user:personal"));
            //var step2Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application2"));
            //var step3Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application3"));
            var sessionId = GetUserSessionId();
            var modelJson = _sessionStorage[$"user:personal:{sessionId}"] as string;
            var corporateJson = _sessionStorage[$"user:corporate:{sessionId}"] as string;
            var application2Json = _sessionStorage[$"user:application2:{sessionId}"] as string;
            var application3Json = _sessionStorage[$"user:application3:{sessionId}"] as string;
            var model = JsonConvert.DeserializeObject<Personal>(modelJson);
            var corporate = JsonConvert.DeserializeObject<Corprate>(corporateJson);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
