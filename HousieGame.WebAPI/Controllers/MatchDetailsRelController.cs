using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Common;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchDetailsRelController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MatchDetailsRel> Get()
        {
            IEnumerable<MatchDetailsRel> objReturn = null;

            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objReturn = objBAL.GetAllRecord();
            }

            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public MatchDetailsRel Get(int id)
        {
            MatchDetailsRel objReturn = null;
            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objReturn = objBAL.GetRecordById(id);
            }
            return objReturn;

        }

        // GET api/<controller>/5
        [HttpGet("List/{matchId}")]
        //[Route("List")]
        public List<int> GetMatchDetailsRel(Guid matchId)
        {
            List<int> objReturn = null;
            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objReturn = objBAL.GetMatchDetailsRelById(matchId);
            }
            return objReturn;

        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]MatchDetailsRel objMatchDetailsRel)
        {
            DefaultResult objReturn = new DefaultResult();

            if (objMatchDetailsRel.Id == 0)
            {
                objMatchDetailsRel.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatchDetailsRel.IsActive = true;
            }

            else
            {
            }

            objMatchDetailsRel.IsDeleted = false;
            objMatchDetailsRel.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);


            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objReturn.Data = objBAL.InsertUpdateRecord(objMatchDetailsRel).ToString();
            }
            int Count;
            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                Count = objBAL.MarkedNumberCount(objMatchDetailsRel.MatchId.GetValueOrDefault());
            }
            if (Count == 90)
            {
                using (Match_BAL objBAL = new Match_BAL())
                {
                    objBAL.ExpireMatchToken(objMatchDetailsRel.MatchId.GetValueOrDefault());
                }
            }

            return objReturn;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public DefaultResult Delete(int id)
        {
            DefaultResult objReturn = new DefaultResult();

            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objReturn.Data = objBAL.DeleteRecord(id).ToString();
            }

            return objReturn;
        }

    }
}
