using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Mailer;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using HousieGame.MatchPrice.BAL;
using HousieGame.PlayerInfo.BAL;
using HousieGame.PlayerInfo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchPlayerPointRelController : Controller
    {
        // GET: api/<controller>
        [HttpGet("{id}")]
        public List<MatchWinner> GetWinner(Guid id)
        {
            List<MatchWinner> objReturn = null;
            using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
            {
                objReturn = objBAL.GetMatchWinner(id);
            }
            return objReturn;
        }


        // POST api/<controller>
        [HttpPost]
        public CheckPlayerPoint Post([FromBody] MatchPlayerPointRel objMatchPlayerPointRel)
        {
            CheckPlayerPoint objReturn = new CheckPlayerPoint();
            string playerTicket;
            int[] matchMarkedNumbers;
            if (objMatchPlayerPointRel.Id == 0)
            {
                objMatchPlayerPointRel.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatchPlayerPointRel.IsActive = true;
            }
            objMatchPlayerPointRel.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            objMatchPlayerPointRel.IsDeleted = false;

            MatchPlayerRel objMatchPlayerRel = null;
            //List<MatchDetailsRel> objMatchDetailsRel = null;

            //Get Player Ticket
            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                objMatchPlayerRel = objBAL.GetMatchPlayer(objMatchPlayerPointRel.PlayerId ,objMatchPlayerPointRel.MatchId);
                playerTicket = objMatchPlayerRel.TokenGeneratedNumber;
            }
            playerTicket = playerTicket.Replace("Empty,", String.Empty);
            //-----
            string first_line = playerTicket.Split('|')[0].Replace("|", String.Empty);
            int s = first_line.LastIndexOf(',');
            first_line = first_line.Remove(s);
            //-----
            string second_line = playerTicket.Split('|')[1].Replace("|", String.Empty);
            int p = second_line.LastIndexOf(',');
            second_line = second_line.Remove(p);
            //-----
            string last_line = playerTicket.Split('|')[2].Replace("|", String.Empty);
            int d = last_line.LastIndexOf(',');
            last_line = last_line.Remove(d);

            string allLine = playerTicket.Replace("|", String.Empty);
            int z = allLine.LastIndexOf(',');
            allLine = allLine.Remove(z);

            string[] firstData = first_line.Replace(" ", String.Empty).Split(',');
            string[] middleData = second_line.Replace(" ", String.Empty).Split(',');
            string[] lastData = last_line.Replace(" ", String.Empty).Split(',');
            string[] allData = allLine.Replace(" ", String.Empty).Split(',');


            //Get Match Marked Numbers
            List<int> objMatchDetailsRel = null;
            using (MatchDetailsRel_BAL objBAL = new MatchDetailsRel_BAL())
            {
                objMatchDetailsRel = objBAL.GetMatchDetailsRelById(objMatchPlayerPointRel.MatchId);
                matchMarkedNumbers = objMatchDetailsRel.ToArray();
            }
            string[] result = matchMarkedNumbers.Select(x => x.ToString()).ToArray();



            //First Line Claim
            if (objMatchPlayerPointRel.FirstLine == true)
            {
                int FirstLine=0;
                for(int i=0; i<firstData.Length; i++)
                {
                    if(result.Contains(firstData[i]))
                    {
                        FirstLine++;
                    }
                }
                //If Claim is Right
                if (FirstLine == firstData.Length) // Make Sure it is used == 
                {
                    MatchPlayerPointRel checkPlayerPoint;
                    bool CheckClaimOfAnotherPlayer;
                    using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                    {
                        checkPlayerPoint = objBAL.CheckPlayerPoint(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        CheckClaimOfAnotherPlayer = objBAL.CheckClaimOfAnotherPlayer(objMatchPlayerPointRel.MatchId, 1);
                    }
                    if (checkPlayerPoint == null)
                    {
                        if (CheckClaimOfAnotherPlayer)
                        {
                            //You are Late some one has already claimed this.
                            objReturn.LateClaim = true;
                        }
                        else
                        {
                            using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                            {
                                objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
                            }
                        }
                    }

                }
                //If Claim is Wrong, Delete User
                else
                {
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        objBAL.WrongClaim(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    //objReturn.ClaimResult = "Wrong";
                    //Player has Claimed Wrong, dont allow to play further.
                    objReturn.WrongClaim = true;
                }

            }


            //Second Line Claim
            else if (objMatchPlayerPointRel.SecondLine == true)
            {
                int SecondLine = 0;
                for (int i = 0; i < middleData.Length; i++)
                {
                    if (result.Contains(middleData[i]))
                    {
                        SecondLine++;
                    }
                }
                if (SecondLine == middleData.Length)
                {
                    MatchPlayerPointRel checkPlayerPoint;
                    bool CheckClaimOfAnotherPlayer;
                    using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                    {
                        checkPlayerPoint = objBAL.CheckPlayerPoint(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        CheckClaimOfAnotherPlayer = objBAL.CheckClaimOfAnotherPlayer(objMatchPlayerPointRel.MatchId, 2);
                    }
                    if (checkPlayerPoint == null)
                    {
                        if (CheckClaimOfAnotherPlayer)
                        {
                            //You are Late some one has already claimed this.
                            objReturn.LateClaim = true;
                        }
                        else
                        {
                            using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                            {
                                objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
                            }
                        }
                    }

                }
                else
                {
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        objBAL.WrongClaim(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    //objReturn.ClaimResult = "Wrong";
                    //Player has Claimed Wrong, dont allow to play further.
                    objReturn.WrongClaim = true;
                }
            }




            //Third Line Claim
            else if (objMatchPlayerPointRel.ThirdLine == true)
            {
                objMatchPlayerPointRel.FirstLine = false;
                objMatchPlayerPointRel.SecondLine = false;
                objMatchPlayerPointRel.FullHousie = false;
                int ThirdLine = 0;
                for (int i = 0; i < lastData.Length; i++)
                {
                    if (result.Contains(lastData[i]))
                    {
                        ThirdLine++;
                    }
                }
                if (ThirdLine == lastData.Length)
                {
                    MatchPlayerPointRel checkPlayerPoint;
                    bool CheckClaimOfAnotherPlayer;
                    using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                    {
                        checkPlayerPoint = objBAL.CheckPlayerPoint(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        CheckClaimOfAnotherPlayer = objBAL.CheckClaimOfAnotherPlayer(objMatchPlayerPointRel.MatchId, 3);
                    }
                    if (checkPlayerPoint == null)
                    {
                        if(CheckClaimOfAnotherPlayer)
                        {
                            //You are Late some one has already claimed this.
                            objReturn.LateClaim = true;
                        }
                        else
                        {
                            using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                            {
                                objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
                            }
                        }
                    }

                }
                else
                {
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        objBAL.WrongClaim(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    //objReturn.ClaimResult = "Wrong";
                    //Player has Claimed Wrong, dont allow to play further.
                    objReturn.WrongClaim = true;
                }
            }




            // Full Housie Claim
            else if (objMatchPlayerPointRel.FullHousie == true)
            {
                int FullHouse = 0;
                for (int i = 0; i < allData.Length; i++)
                {
                    if (result.Contains(allData[i]))
                    {
                        FullHouse++;
                    }
                }
                if (FullHouse == allData.Length)
                {
                    Player player = new Player();
                    MatchPriceRel matchPriceRel = new MatchPriceRel();
                    MatchPlayerPointRel checkPlayerPoint;
                    Match matchObj = new Match();

                    using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                    {
                        checkPlayerPoint = objBAL.CheckPlayerPoint(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    using (Match_BAL objBAL = new Match_BAL())
                    {
                        matchObj = objBAL.GetRecordById(objMatchPlayerPointRel.MatchId);
                    }
                    if (checkPlayerPoint == null)
                    {
                        using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                        {
                            matchPriceRel = objBAL.GetRecordByMatchIdAndDisplayPosition(objMatchPlayerPointRel.MatchId, 4);
                            objBAL.ClaimPrize(objMatchPlayerPointRel.MatchId, 4);
                        }
                        using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                        {
                            objMatchPlayerPointRel.ClaimedPrize = 4;
                            objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
                        }
                        using (Player_BAL objBAL = new Player_BAL())
                        {
                            player = objBAL.GetRecordById(objMatchPlayerPointRel.PlayerId);
                        }
                        using (Match_BAL objBAL = new Match_BAL())
                        {
                            objBAL.ExpireMatchToken(objMatchPlayerPointRel.MatchId);
                        }
                        GMailer mailer = new GMailer();
                        mailer.ToEmail = player.Email;
                        mailer.Subject = "Congratulations " + player.Name + " you won the Prize | Confirm your Address";
                        string mainTemplate = "<!DOCTYPE html><html lang='en'> <head> <title>Bootstrap Example</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css'> <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js'></script> <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js'></script> <script src='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js'></script></head> <body> <h1>Congratulations you have won the Prize for " + matchObj.Title + "</h1><br> See the Attachment image of your prize <br> <h5>Click Below link to confirm the address and claim it.</h5><br><a href='";
                        mainTemplate += "http://localhost:1234/address/" + objMatchPlayerPointRel.MatchId + "' target='_blank'> Click here to claim</a></body></html>";
                        mailer.Body = mainTemplate;
                        mailer.IsHtml = true;
                        mailer.EmailAttachment = "wwwroot/images/" + matchPriceRel.FileName;
                        string a_strMsg = mailer.Send();
                        objReturn.LateClaim = false;
                        objReturn.WrongClaim = false;
                    }

                }
                else
                {
                    using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                    {
                        objBAL.WrongClaim(objMatchPlayerPointRel.MatchId, objMatchPlayerPointRel.PlayerId);
                    }
                    //objReturn.ClaimResult = "Wrong";
                    //Player has Claimed Wrong, dont allow to play further.
                    objReturn.WrongClaim = true;
                }

            }
            else
            {
                using (MatchPlayerPointRel_BAL objBAL = new MatchPlayerPointRel_BAL())
                {
                    objReturn.MatchPlayerPointRelModel = objBAL.InsertUpdateRecord(objMatchPlayerPointRel);
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
        public void Delete(int id)
        {
        }
    }
}
