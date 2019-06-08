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
    public class CheckUpatedAddressController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerPointRel_BAL));
        // GET: api/<controller>
        [HttpGet("{id}")]
        public List<CheckUpdatedAddress> Get(Guid id)
        {
            List<CheckUpdatedAddress> objReturn = null;

            try
            {
                using (MatchPlayerPointRel_BAL objBal = new MatchPlayerPointRel_BAL())
                {
                    objReturn = objBal.GetCheckUpdatedAddresses(id);
                }
            } 
            catch(Exception ex)
            {
                log.Error("CheckUpatedAddress Error: ", ex);
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
