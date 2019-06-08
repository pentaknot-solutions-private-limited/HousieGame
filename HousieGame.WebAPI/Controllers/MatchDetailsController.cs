using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Encryption256AES;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using HousieGame.MatchTokenDetails;
using HousieGame.MatchTokenDetails.BAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchDetailsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            IEnumerable<Match> objReturn = null;

            using (Match_BAL objBAL = new Match_BAL())
            {
                objReturn = objBAL.GetAllRecord();
            }

            return objReturn;
        }

        [HttpGet("upcoming")]
        public IEnumerable<Match> GetUpComingMatch()
        {
            IEnumerable<Match> objReturn = null;

            using (Match_BAL objBAL = new Match_BAL())
            {
                objReturn = objBAL.GetUpComingMatch();
            }

            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Match Get(Guid id)
        {
            // NUMBER function -------------------------------
            //Match objMatch = new Match();
            //objMatch.MatchId = new Guid("442078CE-1F1F-450C-BEF1-FA841C96BBF6");
            //var newToken = KeyGentrator.GenerateToken(objMatch);
            //return newToken;
            //string str = "";
            //for (var i = 0; i < 90; i++)
            //{
            //    var number = GenrateRandomNumber();
            //    if (i == 0)
            //    {
            //        str = number.ToString();
            //    }
            //    else
            //    {
            //        str = str + ',' + number.ToString();
            //    }
            //}
            // END NUMBER function ---------------------------
            //return str;

            Match objReturn = new Match();
            using (Match_BAL objBAL = new Match_BAL())
            {
                objReturn = objBAL.GetRecordById(id);
            }

            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public Guid Post([FromBody] Match objMatch)
        {
            Guid objReturn = new Guid();
            Match Oobj = new Match();
            MatchTokenInfo objMatchtoken = new MatchTokenInfo();

            if (objMatch.Id == 0)
            {
                objMatch.MatchId = Guid.NewGuid();
                objMatch.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatch.IsActive = true;

                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                objMatch.MatchDateTime = TimeZoneInfo.ConvertTimeFromUtc(objMatch.MatchDateTime.GetValueOrDefault(), tz);

                // Match Token
                var newToken = KeyGentrator.GenerateToken(objMatch);
                objMatchtoken.MatchToken = newToken;
                objMatchtoken.MatchId = objMatch.MatchId;
                objMatchtoken.MatchTokenId = Guid.NewGuid();
                objMatchtoken.IsActive = true;
                objMatchtoken.IsDeleted = false;
                objMatchtoken.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatchtoken.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                using (MatchToken_BAL objBAL = new MatchToken_BAL())
                {
                    objReturn = objBAL.InsertUpdateRecord(objMatchtoken);
                }
                // End Match Token

                // NUMBER function -------------------------------
                string str = "";
                for (var i = 0; i < 90; i++)
                {
                    var number = GenrateRandomNumber();
                    if (i == 0)
                    {
                        str = number.ToString();
                    }
                    else
                    {
                        str = str + ',' + number.ToString();
                    }
                }
                // END NUMBER function ---------------------------
                objMatch.MatchGeneratedNumber = str;
            }

            else
            {
                using (Match_BAL objBAL = new Match_BAL())
                {
                    Oobj = objBAL.GetRecordById(objMatch.MatchId);
                }
                if (objMatch.MatchDateTime.GetValueOrDefault().Year == Oobj.MatchDateTime.GetValueOrDefault().Year && objMatch.MatchDateTime.GetValueOrDefault().Month == Oobj.MatchDateTime.GetValueOrDefault().Month && objMatch.MatchDateTime.GetValueOrDefault().Day == Oobj.MatchDateTime.GetValueOrDefault().Day && objMatch.MatchDateTime.GetValueOrDefault().Hour == Oobj.MatchDateTime.GetValueOrDefault().Hour && objMatch.MatchDateTime.GetValueOrDefault().Minute == Oobj.MatchDateTime.GetValueOrDefault().Minute)
                {
                }
                else
                {
                    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    objMatch.MatchDateTime = TimeZoneInfo.ConvertTimeFromUtc(objMatch.MatchDateTime.GetValueOrDefault(), tz);
                }

            }

            objMatch.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            objMatch.IsDeleted = false;

            using (Match_BAL objBAL = new Match_BAL())
            {
                objReturn = objBAL.InsertUpdateRecord(objMatch);
            }

            return objReturn;
        }

        private List<int> numbers = Enumerable.Range(1, 90).ToList();
        private Random rnd = new Random();

        public int GenrateRandomNumber()
        {
            var number = 0;
            try
            {
                if (numbers.Count == 1)
                {
                    number = numbers[0];
                }
                else
                {
                    var index = rnd.Next(0, numbers.Count);
                    number = numbers[index];
                    numbers.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Check------" + ex);
            }

            return number;
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
