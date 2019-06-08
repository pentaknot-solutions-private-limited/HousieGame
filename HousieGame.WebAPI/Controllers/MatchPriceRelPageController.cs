using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.MatchDetails.Model;
using HousieGame.MatchPrice.BAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchPriceRelPageController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        



        // GET api/<controller>/5
        [HttpGet("{PageNo}/{PageSize}")]
        public MatchPriceRelPage Get(int PageNo, string PageSize)
        {
            int iPageSize = Convert.ToInt32(PageSize);
            MatchPriceRelPage objReturn = new MatchPriceRelPage();
            using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
            {
                objReturn = objBAL.GetRecordPage(PageNo, iPageSize);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
