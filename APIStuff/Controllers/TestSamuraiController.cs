using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIStuff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSamuraiController : ControllerBase
    {

        List<string> stringList = new List<string>
        {
            "value1", "value2", "value3"
        };

        // GET: api/<SamuraiController>
        [HttpGet]
        public IEnumerable<string> Get()//plural - ToList()
        {
            return stringList;
        }

        // GET api/<SamuraiController>/5
        [HttpGet("{id}")]
        public string Get(int id)//single
        {
            //vi skal nu loope vores collection igennem og finde det id som der er skrevet
            //har vi arbejdet med noget c# der kan kigge ind i en collection og hente data?
            var result = stringList.Where((g) => g.Contains(id + "")).ToList().FirstOrDefault();

            var result2 = stringList.SingleOrDefault(s => s.Contains(id + ""));

            //var result3 = stringList.SingleOrDefault(o => o.property == id); hvis det er en property i et objekt

            var result4 = stringList[id];//dette er et array

            return result;
        }

        // POST api/<SamuraiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SamuraiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
