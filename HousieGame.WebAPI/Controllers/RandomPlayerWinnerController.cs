using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using HousieGame.PlayerInfo.BAL;
using HousieGame.PlayerInfo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RandomPlayerWinnerController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Player Get(Guid id)
        {
            Player player = new Player();
            Guid RandomPlayerId = new Guid();
            List<MatchPlayerRel> matchPlayerRel = null;
            int Count;
            try
            {
                using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                {
                    Count = objBAL.GetCountById(id);
                }

                Random rnd = new Random();
                var index = rnd.Next(0, Count);
                using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                {
                    matchPlayerRel = objBAL.GetMatchById(id);
                }
                RandomPlayerId = matchPlayerRel.ElementAt(index).PlayerId;
                MatchPlayerPointRel objMatchPlayerPointRel = new MatchPlayerPointRel();
                objMatchPlayerPointRel.MatchId = id;
                objMatchPlayerPointRel.PlayerId = RandomPlayerId;
                objMatchPlayerPointRel.IsActive = true;
                objMatchPlayerPointRel.IsDeleted = false;
                objMatchPlayerPointRel.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatchPlayerPointRel.FirstLine = false;
                objMatchPlayerPointRel.SecondLine = false;
                objMatchPlayerPointRel.ThirdLine = false;
                objMatchPlayerPointRel.FullHousie = false;

                using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                {
                    objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
                }
                using (Player_BAL objBAL = new Player_BAL())
                {
                    player = objBAL.GetRecordById(RandomPlayerId);
                }
            }
            catch (Exception ex)
            {
                return player;
            }
            return player;
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
