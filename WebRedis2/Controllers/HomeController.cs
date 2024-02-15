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
        //private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDictionary<string, object> _sessionStorage;
        private string _dataDirectory;
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

        private string GetDataDirectory()
        {
            if (_dataDirectory == null)
            {
                _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData");
                if (!Directory.Exists(_dataDirectory))
                {
                    Directory.CreateDirectory(_dataDirectory);
                }
            }
            return _dataDirectory;
        }

        public HomeController(ILogger<HomeController> logger, IDictionary<string, object> sessionStorage)
        {
            //_redisConnection = connection;
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
            var filePath = Path.Combine(GetDataDirectory(), $"user_personal_{sessionId}.txt");
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(model));
            return RedirectToAction("App2");
        }

        public IActionResult Corporate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Corporate(Corporate model)
        {
            //_redisConnection.GetDatabase().StringSet("user:corporate", JsonConvert.SerializeObject(model));
            var sessionId = GetUserSessionId();
            _sessionStorage[$"user:corporate:{sessionId}"] = JsonConvert.SerializeObject(model);
            var filePath = Path.Combine(GetDataDirectory(), $"user_corporate_{sessionId}.txt");
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(model));
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
            var filePath = Path.Combine(GetDataDirectory(), $"user_application2_{sessionId}.txt");
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(model));
            return RedirectToAction("App3");
        }

        public IActionResult App3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult App3(Application3 model)
        {
            //_redisConnection.GetDatabase().StringSet("user:application3", JsonConvert.SerializeObject(model));
            var sessionId = GetUserSessionId();
            _sessionStorage[$"user:application3:{sessionId}"] = JsonConvert.SerializeObject(model);
            var filePath = Path.Combine(GetDataDirectory(), $"user_application2_{sessionId}.txt");
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(model));
            return RedirectToAction("FinalStep");
        }

        public IActionResult FinalStep()
        {
            var sessionId = GetUserSessionId();
            var personalFilePath = Path.Combine(GetDataDirectory(), $"user_personal_{sessionId}.txt");
            var corporateFilePath = Path.Combine(GetDataDirectory(), $"user_corporate_{sessionId}.txt");
            var application2FilePath = Path.Combine(GetDataDirectory(), $"user_application2_{sessionId}.txt");
            var application3FilePath = Path.Combine(GetDataDirectory(), $"user_application3_{sessionId}.txt");

            Personal personal = JsonConvert.DeserializeObject<Personal>(System.IO.File.ReadAllText(personalFilePath));
            Corporate corporate = JsonConvert.DeserializeObject<Corporate>(System.IO.File.ReadAllText(corporateFilePath));
            Application2 application2 = JsonConvert.DeserializeObject<Application2>(System.IO.File.ReadAllText(application2FilePath));
            Application3 application3 = JsonConvert.DeserializeObject<Application3>(System.IO.File.ReadAllText(application3FilePath));

            return View();
        }

        //public IActionResult FinalStep()
        //{
         
        //    //var model = JsonConvert.DeserializeObject<Personal>(_redisConnection.GetDatabase().StringGet("user:personal"));
        //    //var step2Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application2"));
        //    //var step3Data = JsonConvert.DeserializeObject<Application2>(_redisConnection.GetDatabase().StringGet("user:application3"));
        //    var sessionId = GetUserSessionId();
        //    var modelJson = _sessionStorage[$"user:personal:{sessionId}"] as string;
        //    var corporateJson = _sessionStorage[$"user:corporate:{sessionId}"] as string;
        //    var application2Json = _sessionStorage[$"user:application2:{sessionId}"] as string;
        //    var application3Json = _sessionStorage[$"user:application3:{sessionId}"] as string;
        //    var model = JsonConvert.DeserializeObject<Personal>(modelJson);
        //    var corporate = JsonConvert.DeserializeObject<Corporate>(corporateJson);
        //    var application2 = JsonConvert.DeserializeObject<Application2>(application2Json);
        //    var application3 = JsonConvert.DeserializeObject<Application3>(application3Json);
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
