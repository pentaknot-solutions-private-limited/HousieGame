using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Common;
using HousieGame.Encryption256AES;
using HousieGame.PlayerInfo.BAL;
using HousieGame.PlayerInfo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
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
            Player objReturn = new Player();
            using (Player_BAL objBAL = new Player_BAL())
            {
                objReturn = objBAL.GetRecordById(id);
                objReturn.PasswordHash = EncryptionLibrary.DecryptText(objReturn.PasswordHash);
            }

            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody] Player objPlayer)
        {
            DefaultResult objReturn = new DefaultResult();

            if (objPlayer.Id == 0)
            {
                objPlayer.PlayerId = Guid.NewGuid();
                objPlayer.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objPlayer.IsActive = true;
                objPlayer.PasswordHash = EncryptionLibrary.EncryptText(objPlayer.PasswordHash);
            }
            else
            {
                objPlayer.PasswordHash = EncryptionLibrary.EncryptText(objPlayer.PasswordHash);
            }

            objPlayer.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            objPlayer.IsDeleted = false;

            using (Player_BAL objBAL = new Player_BAL())
            {
                objReturn.Data = objBAL.InsertUpdateRecord(objPlayer).ToString();
            }

            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Login")]
        public Player Login([FromBody] Player objPlayer)
        {
            Player objReturn = new Player();
            objPlayer.PasswordHash = EncryptionLibrary.EncryptText(objPlayer.PasswordHash);
            using (Player_BAL objBAL = new Player_BAL())
            {
                objReturn = objBAL.ValidatePlayer(objPlayer.Email, objPlayer.PasswordHash);
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
