using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fenergo.HealthChecker.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Fenergo.HealthChecker.Controllers
{
    public class HomeController : Controller
    {
        const string urlApi = "http://localhost/Fenergo.HealthChecker.WebApi/api/Checker";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Diagnose()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Diagnose(List<int> diagnoseTypes)
        {
            var json = JsonConvert.SerializeObject(diagnoseTypes);
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.PostAsJsonAsync(urlApi, json))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    var response = JsonConvert.DeserializeObject(data);
                }

                return View();
            }

        }
    }
}
