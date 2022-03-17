using back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    [ApiController]
    [Route("api/[controller]")]

    public class FunctionaryController : ControllerBase
    {

        private TECH_TEST_G_HURTADOContext _tECH_TEST_G_HURTADOContext;

        public FunctionaryController(TECH_TEST_G_HURTADOContext tECH_TEST_G_HURTADOContext)
        {
            _tECH_TEST_G_HURTADOContext = tECH_TEST_G_HURTADOContext;
        }

        [HttpGet]
        public IEnumerable<Functionary> Get()
        {
            return _tECH_TEST_G_HURTADOContext.Functionaries;
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _tECH_TEST_G_HURTADOContext.Functionaries();
        //    return Ok(users);
        //}

        //[HttpGet]
        //public JsonResult Get()
        //{

        //    return new JsonResult(_tECH_TEST_G_HURTADOContext.Functionaries);
        //}

        [HttpPost]
        public void Post([FromBody] Functionary value)
        {
            _tECH_TEST_G_HURTADOContext.Functionaries.Add(value);
            _tECH_TEST_G_HURTADOContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Functionary value)
        {
            var functionary = _tECH_TEST_G_HURTADOContext.Functionaries.FirstOrDefault(s => s.FunctionaryGpn == id);
            if (functionary != null)
            {
                _tECH_TEST_G_HURTADOContext.Entry<Functionary>(functionary).CurrentValues.SetValues(value);
                _tECH_TEST_G_HURTADOContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var functionary = _tECH_TEST_G_HURTADOContext.Functionaries.FirstOrDefault(s => s.FunctionaryGpn == id);
            if (functionary != null)
            {
                _tECH_TEST_G_HURTADOContext.Functionaries.Remove(functionary);
                _tECH_TEST_G_HURTADOContext.SaveChanges();
            }
        }



    }
}
