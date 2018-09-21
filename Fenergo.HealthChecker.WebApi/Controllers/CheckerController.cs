using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fenergo.HealthChecker.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fenergo.HealthChecker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CheckerController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public string Post([FromBody]string value = "[0, 1, 2, 4]")
        {
            var obj = JsonConvert.DeserializeObject<List<int>>(value);
            var enumList = obj.Select(x => (ProcessorTypeEnum)x);
            var result = new Processor().Execute(enumList.ToList());
            return JsonConvert.SerializeObject(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
