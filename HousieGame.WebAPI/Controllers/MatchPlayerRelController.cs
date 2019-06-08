using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousieGame.Common;
using HousieGame.MatchDetails.BAL;
using HousieGame.MatchDetails.Model;
using HousieGame.Mailer;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using CoreHtmlToImage;
using HousieGame.PlayerInfo.Model;
using HousieGame.PlayerInfo.BAL;
using Match = HousieGame.MatchDetails.Model.Match;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousieGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MatchPlayerRelController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MatchPlayerRel> Get()
        {
            IEnumerable<MatchPlayerRel> objReturn = null;

            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                objReturn = objBAL.GetAllRecord();
            }

            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public MatchPlayerRel Get(Guid id)
        {
            MatchPlayerRel objReturn = null;
            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                objReturn = objBAL.GetRecordById(id);
            }
            return objReturn;

        }


        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody] MatchPlayerRel objMatchPlayerRel)
        {
            Player player = new Player();
            MatchPlayerRel PlayerObj = null;
            using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
            {
                PlayerObj = objBAL.GetPlayerById(objMatchPlayerRel.PlayerId, objMatchPlayerRel.MatchId);
            }

            DefaultResult objReturn = new DefaultResult();

            if (PlayerObj == null)
            {
                if (objMatchPlayerRel.Id == 0)
                {
                    objMatchPlayerRel.CreationDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    objMatchPlayerRel.IsActive = true;
                    Programe prg = new Programe();
                    objMatchPlayerRel.TokenGeneratedNumber = prg.Mains();
                }

                objMatchPlayerRel.UpdatedDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                objMatchPlayerRel.IsDeleted = false;


                //Email Ticket
                var emailTicketTemplate = objMatchPlayerRel.TokenGeneratedNumber;
                Match matchObj = new Match();
                using (Player_BAL objBAL = new Player_BAL())
                {
                    player = objBAL.GetRecordById(objMatchPlayerRel.PlayerId);
                }
                using (Match_BAL objBAL = new Match_BAL())
                {
                    matchObj = objBAL.GetRecordById(objMatchPlayerRel.MatchId);
                }

                GMailer mailer = new GMailer();
                //mailer.ToEmail = "amitn917@gmail.com";
                mailer.ToEmail = player.Email;
                mailer.Subject = "Housie/ Tambola Ticket.";
                //string a_Bodyobj = emailTicketTemplate.Replace("Empty", String.Empty);
                string first_line = emailTicketTemplate.Split('|')[0].Replace("|", String.Empty);
                string second_line = emailTicketTemplate.Split('|')[1].Replace("|", String.Empty);
                string last_line = emailTicketTemplate.Split('|')[2].Replace("|", String.Empty);
                string youtubeLink = "https://www.youtube.com/channel/UCpGv-Kibvylx4hHGye8__nQ";
                string mailFormat = "How to play : <ul><li>Get your free ticket from <a href='thegamingbirds.com'> thegamingbirds.com</a></li> <li>Write down your ticket numbers on paper in the same format as sent to your Email. </li> <li> Join our YouTube live at <a href='" + youtubeLink + "'>Gaming Birds</a> on " + matchObj.MatchDateTime + " and Play Traditional Housie in a new way.</li> <li> If you win click on the prize claiming link in description of YouTube live.</li> <li>Prize will be delivered directly to you.</li> <li>Enjoy & Spread love with family & Friends ❣️</li></ul> <br> Or <br>You can also watch our video to see how to play.<br><br> Also Don't forget to Subscribe our channel <a href='" + youtubeLink + "'>Gaming Birds</a> and hit the bell icon to get notifications before every game. <br> <br> Note - Wrong claim will lead to disqualification from the game.<br>";
                string mainTemplate = "<!DOCTYPE html><html lang='en'> <head> <title>Bootstrap Example</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css'> <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js'></script> <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js'></script> <script src='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js'></script></head> <body> <div class='container'>" + mailFormat +"<table border='1'> <tr>";
                string[] firstData = first_line.Replace(" ", String.Empty).Split(',');
                foreach (string item in firstData)
                {
                    if (item != firstData[firstData.Length - 1])
                    {
                        if (item == "Empty")
                        {
                            mainTemplate += "<td style='background-color: black; min-width: 31px; color: white; font-size: 24px;'>" + String.Empty + "</td>";
                        }
                        else
                        {
                            if (item == firstData[0])
                            {
                                mainTemplate += "<td style='background-color: white; min-width: 31px; color: black;font-size: 24px;'>" + item.PadLeft(2, '0') + "</td>";
                            }
                            else
                            {
                                mainTemplate += "<td style='background-color: white; min-width: 31px; color: black;font-size: 24px;'>" + item + "</td>";
                            }
                        }
                    }
                }
                mainTemplate += "</tr><tr>";

                string[] middleData = second_line.Replace(" ", String.Empty).Split(',');

                foreach (string item in middleData)
                {
                    if (item != middleData[middleData.Length - 1])
                    {
                        if (item == "Empty")
                        {
                            mainTemplate += "<td style='background-color: black; min-width: 31px; color: white; font-size: 24px;'>" + String.Empty + "</td>";
                        }
                        else
                        {
                            if (item == middleData[0])
                            {
                                mainTemplate += "<td style='background-color: white; color: black; min-width: 31px; font-size: 24px;'>" + item.PadLeft(2, '0') + "</td>";
                            }
                            else
                            {
                                mainTemplate += "<td style='background-color: white; color: black; min-width: 31px; font-size: 24px;'>" + item + "</td>";
                            }

                        }
                    }
                }
                mainTemplate += "</tr><tr>";

                string[] lastData = last_line.Replace(" ", String.Empty).Split(',');

                foreach (string item in lastData)
                {
                    if (item != lastData[lastData.Length - 1])
                    {
                        if (item == "Empty")
                        {
                            mainTemplate += "<td style='background-color: black; color: white; font-size: 24px;'>" + String.Empty + "</td>";
                        }
                        else
                        {
                            if (item == lastData[0])
                            {
                                mainTemplate += "<td style='background-color: white; color: black;font-size: 24px;'>" + item.PadLeft(2, '0') + "</td>";
                            }
                            else
                            {
                                mainTemplate += "<td style='background-color: white; color: black;font-size: 24px;'>" + item + "</td>";
                            }
                        }
                    }
                }
                string Bodyobj = mainTemplate + "</tr></table></div></body></html>";
                String filedir = Path.Combine("wwwroot/ticket/");

                if (!Directory.Exists(filedir))
                {
                    Directory.CreateDirectory(filedir);
                }

                var converter = new HtmlConverter();
                var bytes = converter.FromHtmlString(Bodyobj, 284);
                Random random = new Random();
                var fileName = random.NextDouble();
                System.IO.File.WriteAllBytes("wwwroot/ticket/" + fileName + ".jpg", bytes);
                mailer.EmailAttachment = "wwwroot/ticket/" + fileName + ".jpg";
                mailer.Body = Bodyobj;
                mailer.IsHtml = true;

                string a_strMsg = mailer.Send();

                using (MatchPlayerRel_BAL objBAL = new MatchPlayerRel_BAL())
                {
                    objReturn.Data = objBAL.InsertUpdateRecord(objMatchPlayerRel).ToString();
                }
            }

            else
            {
                objReturn.Message = "enrolled";
            }

            return objReturn;
        }

        // CODE for ticket genration

        public class Programe
        {
            List<bool[]> permutations = new List<bool[]>();

            public string Mains()
            {
                Programe prg = new Programe();
                // Generate all possible permutations of 9 items
                // 511 is 9 1-bits
                string objreturn = "";
                for (uint n = 0; n < 512; n++)
                {
                    bool[] p = perm(n);
                    if (valid(p))
                    {
                        permutations.Add(p);
                    }
                }

                Random rnd = new Random();
                for (var k = 0; k < 3; k++)
                {
                    int r = rnd.Next(permutations.Count);
                    Console.Write("     {0} = ", r);
                    for (int i = 0; i < 9; i++)
                    {
                        int j = 0;
                        j = i + 1;
                        // NUMBER function -------------------------------
                        // Console.Write(permutations[r][i] ? string.Concat(prg.GenrateRandomNumber(j.ToString()).ToString(), ", ") : "Empty, ");
                        var rt = permutations[r][i] ? string.Concat(prg.GenrateRandomNumber(j.ToString()).ToString(), ", ") : "Empty, ";
                        objreturn = objreturn + rt;
                        // END NUMBER function ---------------------------
                    }
                    objreturn = string.Concat(objreturn, "|");
                    Console.WriteLine();

                }
                return objreturn;
            }

            // Convert a number into a bit pattern (array of 9 bools)
            // Representing number (true) or gap (false)
            bool[] perm(uint n)
            {
                bool[] result = new bool[9];
                uint m = 1;
                for (int i = 0; i < 9; m <<= 1, i++)
                    result[i] = (n & m) != 0;
                return result;
            }

            // See if a bit pattern satisfies the rules
            bool valid(bool[] p)
            {
                int repeat = 0;     // Number of trues (numbers) or falses (gaps)
                int count = 0;      // Number of trues (numbers)
                bool last = false;
                for (int n = 0; n < 9; n++)
                {
                    bool current = p[n];
                    if (current == last)
                    {
                        // This is the same as the last one (i.e. both numbers or both gaps)
                        if (++repeat > 2)
                            return false; // May not have more than 2 of the same together
                    }
                    else
                    {
                        repeat = 1;
                    }
                    if (current)
                        count++;
                    last = current;
                }
                return count == 5;
            }

            private List<int> numbers = Enumerable.Range(0, 90).ToList();
            private Random rnd = new Random();

            public int GenrateRandomNumber(string a)
            {
                int j = Int32.Parse(string.Concat(a, '0'));
                var index = 0;
                if (a == "1")
                {
                    do
                    {
                        index = rnd.Next(1, j - 1);
                    } while (numbers.Find(l => l == index) == 0);
                }
                else
                {
                    do
                    {
                        index = rnd.Next(j - 10, j - 1);
                    } while (numbers.Find(l => l == index) == 0);
                }
                var number = numbers.Find(l => l == index);
                numbers.Remove(index);
                return number;
            }
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
