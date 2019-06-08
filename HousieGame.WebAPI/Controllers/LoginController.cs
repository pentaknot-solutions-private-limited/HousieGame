using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.AdminInfo.BAL;
using HousieGame.AdminInfo.Model;
using HousieGame.Encryption256AES;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{email}/{password}")]
        public bool Validate(string email, string password)
        {
            bool objReturn = false;

            password = EncryptionLibrary.EncryptText(password);
            using (Admin_BAL objBAL = new Admin_BAL())
            {
                // objReturn = objBAL.Validate(email, password);
            }

            return objReturn;

        }

        // POST api/<controller>
        [HttpPost]
        public Admin Post([FromBody]Login objLogin)
        {
            Admin objReturn = null;

            objLogin.Password = EncryptionLibrary.EncryptText(objLogin.Password);
            using (Admin_BAL objBAL = new Admin_BAL())
            {
                objReturn = objBAL.Validate(objLogin.EmailId, objLogin.Password);
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
