using Pidu_proov.Models;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Pidu_proov.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Rakenduse kirjelduse leht.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktilehekülg.";

            return View();
        }
        [HttpGet]
        public ActionResult Ankeet()
        {
            var pyhad= db.Pyhad.ToList();
            //ViewBag.Pyhad = pyhad;// Edastame pühade nimekirja vaatesse
            ViewBag.Pyhad = new SelectList(pyhad, "Id","Nimetus","Kuupaev");// Edastame pühade nimekirja vaatesse
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ankeet(Kylaline kylaline)
        {
            if (ModelState.IsValid)
            {
                db.Kylalised.Add(kylaline);
                db.SaveChanges();
                return RedirectToAction("Tanan", new { id = kylaline.Id });//kylaline
            }
            var pyhad = db.Pyhad.ToList();
            ViewBag.Pyhad = new SelectList(pyhad, "Id", "Nimetus", kylaline.PyhaId);// Edastame pühade nimekirja vaatesse
            return View(kylaline);
        }
        public ActionResult Tanan(int id)
        {
            var kylaline = db.Kylalised.Find(id);
            if (kylaline == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pyhanimetus = db.Pyhad.Find(kylaline.PyhaId)?.Nimetus;
            //ViewBag.Pilt= "pilt.png";
            if (kylaline.OnKutse)
            {
                ViewBag.Pilt = "pilt.png";
            }
            else
            {
                ViewBag.Pilt = "ei_tule.png";
            }
            SaadaEmail(kylaline, ViewBag.Pilt, ViewBag.Pyhanimetus);
            return View("Tanan",kylaline);
        }
        //https://myaccount.google.com/apppasswords Meetod e-kirja saatmiseks
        private void SaadaEmail(Kylaline kylaline, string pilt, string pyha)
        {
            string failiTee = Path.Combine(Server.MapPath("~/Images/"), pilt);
            try
            {
                // SMTP seadistamine (Gmail näide)
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "oleinik.marina@gmail.com"; // Sinu e-post
                WebMail.Password = "bqwx pyyu pljv zbst"; //"sinu_rakenduse_parool"; // Google App Password
                WebMail.From = "oleinik.marina@gmail.com";

                // Kirja sisu koostamine
                string sisu = "";
                if (kylaline.OnKutse)
                {
                    sisu = $"Tere, {kylaline.Nimi}!<br/><br/>" +
                                  $"Sinu registreerumine sündmusele <b>{pyha}</b> on salvestatud.<br/>" +
                                  "Lisasime kirjale ka sündmuse kutse. Ootame sind väga!<br/><br/>" +
                                  "Kohtumiseni!";
                }
                else 
                {
                    sisu = $"Tere, {kylaline.Nimi}!<br/><br/>" +
                                  $"Sinu registreerumine sündmusele <b>{pyha}</b> on salvestatud.<br/>" +
                                  "Lisasime kirjale ka sündmuse kutse. Kahju, et sa ei tule peole!<br/><br/>" +
                                  "Kõige head!";
                }

                // Saada kiri koos manusega
                WebMail.Send(
                    to: kylaline.Email,
                    subject: "Vastus: " + pyha,
                    body: sisu,
                    isBodyHtml: true,
                    filesToAttach: new string[] { failiTee } // Lisa pilt manusena
                );
            }
            catch (System.Exception ex)
            {
                // Veatuvastus (valikuline)
                System.Diagnostics.Debug.WriteLine("E-maili viga: " + ex.Message);
            }
        }
    }
}