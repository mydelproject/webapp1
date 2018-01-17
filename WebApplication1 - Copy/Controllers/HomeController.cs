using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private PERFTESTINGContext db = null;

        public HomeController(PERFTESTINGContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchScript()
        {

            var query = from c in db.AutoTestResults
                        orderby c.Sno ascending
                        select c;
            return View(query.ToList());


        }
       

        [HttpPost]
        public IActionResult GetScript(string id)
        {
            //string sname = HttpContext.Request.Form["inputGroupSelect01"].ToString();

            var query = db.AutoTestResults.Where(x => x.ScriptName == id);

            //from c in db.AutoTestResults
            //        where c.ScriptName == sname
            //        orderby c.Sno ascending
            //        select c;
            ViewData.Add(new KeyValuePair<string, object>("ScriptNameList"
                , new List<AutoTestResults>(query.ToList())));

            var selectoption = from c in db.AutoTestResults
                               orderby c.Sno ascending
                               select c;

            return View("SearchScript", selectoption.ToList());
        }

        [HttpPost]
        public IActionResult InsertScript(int id)
        {
            //string sname = HttpContext.Request.Form["inputGroupSelect01"].ToString();

            var query = db.AutoTestResults.Where(x => x.Sno == id);

            //from c in db.AutoTestResults
            //        where c.ScriptName == sname
            //        orderby c.Sno ascending
            //        select c;
            ViewData.Add(new KeyValuePair<string, object>("ScriptNameList"
                , new List<AutoTestResults>(query.ToList())));

            var selectoption = from c in db.AutoTestResults
                               orderby c.Sno ascending
                               select c;
            
            return View("SearchScript", selectoption.ToList());
        }

        public IActionResult SearchScriptByName()
        {


            var query = from c in db.AutoTestResults
                        //where c.ScriptName == @ViewData["ScriptName"].ToString()
                        orderby c.Sno ascending
                        select c;
            ViewData.Add(new KeyValuePair<string, object>("ScriptNameList", new List < AutoTestResults > (query.ToList())));
           
            return View(RedirectToAction("SearchScript") );

        }

        public IActionResult ExecuteScript()
        {

            var query = from c in db.AutoTestResults
                        orderby c.Sno ascending
                        select c;
            return View(query.ToList());


        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
