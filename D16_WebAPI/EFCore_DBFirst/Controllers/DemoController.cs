using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EFCore_DBFirst.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        public static List<string> Data = new List<string>
        {
            "Cam", "Bưởi", "Đào", "Mận", "Ổi"
        };

        // GET: api/Demo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Data;
        }

        // GET: api/Demo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= Data.Count)
                return this.BadRequest("Id không hợp lệ");

            return this.Ok(Data[id]);
        }

        // POST: api/Demo
        [HttpPost]
        public void Post([FromBody] RequestInfo obj)
        {
            Data.Add(obj.Value);
        }

        // PUT: api/Demo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RequestInfo obj)
        {
            if (id < 0 || id >= Data.Count)
                return this.BadRequest("Id không hợp lệ");

            Data[id] = obj.Value;
            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= Data.Count)
                return this.BadRequest("Id không hợp lệ");
            Data.RemoveAt(id);
            return this.StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
