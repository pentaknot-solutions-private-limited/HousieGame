using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Common;
using HousieGame.MatchDetails.Model;
using HousieGame.MatchPrice.BAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchPriceRelController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MatchPriceRel> Get()
        {
            IEnumerable<MatchPriceRel> objReturn = null;

            using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
            {
                objReturn = objBAL.GetAllRecord();
            }

            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public List<MatchPriceRel> Get(Guid id)
        {
            List<MatchPriceRel> objReturn = null;
            using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
            {
                objReturn = objBAL.GetRecordsById(id);
            }
            return objReturn;

        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]MatchPrizeRel obj)
        {
            DefaultResult objReturn = new DefaultResult();
            String filedir = Path.Combine("wwwroot/images/");

            if (!Directory.Exists(filedir))
            {
                Directory.CreateDirectory(filedir);
            }

            for (int i = 0; i < obj.ImageDetails.Count; i++)
            {
                MatchPriceRel objCheck = new MatchPriceRel();
                using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                {
                    objCheck = objBAL.GetRecordByMatchIdAndDisplayPosition(obj.MatchId.GetValueOrDefault(), obj.ImageDetails[i].DisplayPosition);
                }

                if (!string.IsNullOrEmpty(obj.ImageDetails[i].FileName))
                {
                    if (objCheck != null)
                    {
                        DefaultResult objDelete = new DefaultResult();

                        using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                        {
                            objDelete.Data = objBAL.DeleteRecord(objCheck.Id).ToString();
                        }
                    }

                    Guid ImgName = Guid.NewGuid();

                    string file = Path.Combine(filedir, ImgName + ".png");
                    if (obj.ImageDetails[i].FileName.Length > 100)
                    {
                        var bytes = Convert.FromBase64String(obj.ImageDetails[i].FileName);
                        if (bytes.Length > 0)
                        {
                            using (var stream = new FileStream(file, FileMode.Create))
                            {
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Flush();
                            }
                        }

                        MatchPriceRel objMatchPriceRel = new MatchPriceRel();

                        objMatchPriceRel.MatchId = obj.MatchId.GetValueOrDefault();
                        objMatchPriceRel.DisplayPosition = obj.ImageDetails[i].DisplayPosition;
                        objMatchPriceRel.FileName = ImgName.ToString() + ".png";

                        if (objMatchPriceRel.Id == 0)
                        {
                            objMatchPriceRel.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                            objMatchPriceRel.IsActive = true;
                        }

                        objMatchPriceRel.IsDeleted = false;
                        objMatchPriceRel.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);

                        using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
                        {
                            objReturn.Data = objBAL.InsertUpdateRecord(objMatchPriceRel).ToString();
                        }
                    }
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

            using (MatchPriceRel_BAL objBAL = new MatchPriceRel_BAL())
            {
                objReturn.Data = objBAL.DeleteRecord(id).ToString();
            }

            return objReturn;
        }
    }
}
