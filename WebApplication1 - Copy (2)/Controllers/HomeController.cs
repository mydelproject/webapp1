using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
       
        public IActionResult getDataInBackground()
        {
            string testName = Request.QueryString.Value;

            testName.Replace("{", "").Replace("?","").Replace("}","");
            var query = db.AutoTestResults.Where(x => x.ScriptName == testName);
            ViewData.Add(new KeyValuePair<string, object>("BackgroundData"
              , new List<AutoTestResults>(query.ToList())));

            return PartialView("container1");
        }
        public IActionResult SearchScript()
        {

            //var query = from c in db.AutoTestResults
            //            orderby c.Sno ascending
            //            select c;
            //ViewBag.ListofScriptName = query.ToList();
            //return View(query.ToList());

            var query = db.AutoTestResults.AsEnumerable()
                        .Select(row => row.ScriptName
                        )
                        .Distinct();

            ViewBag.ListofScriptName = query.ToList();
            return View(query.ToList());


        }


        [HttpPost]
        public IActionResult GetScript(string id)
        {

            string []sname = Request.Form.Keys.ToArray();

            var query = db.AutoTestResults.Where(x => x.ScriptName == sname[0]);

            //from c in db.AutoTestResults
            //        where c.ScriptName == sname
            //        orderby c.Sno ascending
            //        select c;
            ViewData.Add(new KeyValuePair<string, object>("ScriptNameList"
                , new List<AutoTestResults>(query.ToList())));

            var selectoption = db.AutoTestResults.AsEnumerable()
                        .Select(row => row.ScriptName
                        )
                        .Distinct();

            return View("SearchScript", selectoption.ToList());
        }

        [HttpPost]
        public IActionResult InsertScript(int id)
        {
            string scriptName = "";
            string IsExecute = "N";
            string ExecutionDate = "";

            string[] sname = Request.Form.Keys.ToArray();

           
            if (sname.Length == 3)
            {
                scriptName = sname[0];
                ExecutionDate = sname[1];
               
            }
            if (sname.Length == 4)
            {
                scriptName = sname[0];
                ExecutionDate = sname[1];
                if (sname[2] == "Checked")
                {
                    IsExecute = "Y";
                }
               
            }

            var query = from c in db.AutoTestNameRefData
                        select c;

            //var selectoption = db.AutoTestResults.Where(x => x.Sno == Sno);
            


            AutoTestExecution data = new AutoTestExecution();

           
              
                data.ScriptName = sname[0];
                data.IsExecute = IsExecute;
                data.ExecutionDate =Convert.ToDateTime(ExecutionDate);
            
            db.AutoTestExecution.Add(data);
            db.SaveChanges();




            return View("ExecuteScript", query.ToList());
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

            var query = from c in db.AutoTestNameRefData
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
