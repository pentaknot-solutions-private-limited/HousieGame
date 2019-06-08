using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Common;
using HousieGame.Mailer;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using HousieGame.MatchPrice.BAL;
using HousieGame.PlayerInfo.BAL;
using HousieGame.PlayerInfo.Model;
using log4net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClaimPrizeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerPointRel));
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MatchPriceRel> Get()
        {
            IEnumerable<MatchPriceRel> objReturn = null;

            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public CheckPlayerPoint Post([FromBody]MatchPlayerPointRel obj)
        {
            Player player = new Player();
            MatchPriceRel matchPriceRel = new MatchPriceRel();
            CheckPlayerPoint objReturn = new CheckPlayerPoint();
            Match matchObj = new Match();

            try
            {
                using (Match_BAL objBAL = new Match_BAL())
                {
                    matchObj = objBAL.GetRecordById(obj.MatchId);
                }
                using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                {
                    matchPriceRel = objBAL.GetRecordByMatchIdAndDisplayPosition(obj.MatchId, obj.ClaimedPrize);
                }
                using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                {
                    objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(obj);
                }
                using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                {
                    objBAL.ClaimPrize(obj.MatchId, obj.ClaimedPrize);
                }
                using (Player_BAL objBAL = new Player_BAL())
                {
                    player = objBAL.GetRecordById(obj.PlayerId);
                }

                GMailer mailer = new GMailer();
                mailer.ToEmail = player.Email;
                mailer.Subject = "Congratulations " + player.Name + " you won the Prize | Confirm your Address";
                string mainTemplate = "<!DOCTYPE html><html lang='en'> <head> <title>Bootstrap Example</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css'> <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js'></script> <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js'></script> <script src='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js'></script></head> <body> <h1>Congratulations you have won the Prize for " + matchObj.Title + "</h1><br> See the Attachment image of your prize <br> <h5>Click Below link to confirm the address and claim it.</h5><br><a href='";
                mainTemplate += "http://localhost:1234/address/" + obj.MatchId + "' target='_blank'> Click here to claim</a></body></html>";
                mailer.Body = mainTemplate;
                mailer.IsHtml = true;
                mailer.EmailAttachment = "wwwroot/images/" + matchPriceRel.FileName;
                string a_strMsg = mailer.Send();
                objReturn.LateClaim = false;
                objReturn.WrongClaim = false;
            } 
            catch (Exception ex)
            {
                log.Error("Claim Prize Error", ex);
                return null;
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

            using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
            {
                objReturn.Data = objBAL.DeleteRecord(id).ToString();
            }

            return objReturn;
        }
    }
}
