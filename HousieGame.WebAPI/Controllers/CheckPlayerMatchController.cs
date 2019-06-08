using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CheckPlayerMatchController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{playerId}/{matchId}")]
        public CheckPlayerMatch CheckPlayer(Guid playerId, Guid matchId)
        {
            CheckPlayerMatch objReturn = new CheckPlayerMatch();
            MatchPlayerPointRel checkPlayerPoint = new MatchPlayerPointRel();
            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                objReturn = objBAL.CheckPlayerMatch(playerId, matchId);
            }
            try
            {
                using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                {
                    checkPlayerPoint = objBAL.CheckPlayerPoint(matchId, playerId);
                }
                using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                {
                    objReturn.Count = objBAL.MarkedNumberCount(matchId);
                }
                if (checkPlayerPoint != null)
                {
                    objReturn.AlreadyClaim = true;
                }
                else
                {
                    objReturn.AlreadyClaim = false;
                }

            }
            catch(Exception ex)
            {
                objReturn = null;
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
        public void Delete(int id)
        {
        }
    }
}
