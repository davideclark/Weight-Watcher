using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [Authorize]
    public class WeightController : Controller
    {
        WeightModel weightRecords = new WeightModel();

        //public ActionResult Index(int? page)
        //{
        //    int? pageSize = 5;
        //    int count = 0;
        //    var weights = weightRecords.GetWeights(User.Identity.Name, null, page, pageSize, "", out count).ToList();
        //    return View("Index", weights);
        //}

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int totalCount = -1;
            var weights = weightRecords.GetWeights(User.Identity.Name, null, page, pageSize, "", out totalCount).ToList();
            var paginatedDinners = new PaginatedList<WeightRecord>(weights, page ?? 0, pageSize, totalCount);
            return View("Index", paginatedDinners);
        }

        //
        // GET: /Weight/Details/2
        public ActionResult Details(int id)
        {
            int count = 0;
            List<WeightRecord> r = weightRecords.GetWeights(null, id, null, null, "", out count);
            if (!(r.Count > 0))
                return View("NotFound");
            else
                return View("Details", r[0]);
        }

        public ActionResult Edit(int id)
        {
            int count = 0;
            List<WeightRecord> r = weightRecords.GetWeights(null, id, null, null, "", out count);
            if (r.Count > 0)
                return View(r[0]);
            else
                return View("NotFound");
        }

        //
        // POST: /Dinners/Edit/2
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            int count = 0;
            List<WeightRecord> r = weightRecords.GetWeights(null, id, null, null, "", out count);
            try
            {
                // Retrieve existing weight record

                if (r.Count > 0)
                {
                    // Update weight with form posted values
                    //r[0].Date = Convert.ToDateTime(Request.Form["Date"]);
                    //r[0].Weight = Convert.ToDouble(Request.Form["Weight"]);

                    UpdateModel(r[0]);

                    r[0].Validate();
                    weightRecords.Update(r[0]);

                }
                //// Persist changes back to database
                //// Perform HTTP redirect to details page for the saved Dinner
                return RedirectToAction("Details", new { id = r[0].WeightRecordID });
            }
            catch
            {
                ModelState.AddRuleViolations(r[0].GetRuleViolations());
                return View(r[0]);
            }
        }


        //Get: /Weight/Create
        public ActionResult Create()
        {
            WeightRecord weightRecord = new WeightRecord();
            weightRecord.Date = DateTime.Now;

            return View(weightRecord);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(WeightRecord r2)
        {
            WeightRecord r = new WeightRecord();
            try
            {
                r.UserName = User.Identity.Name;

                UpdateModel(r);

                int newId = weightRecords.Add(r);

                return RedirectToAction("Details", new { id = newId });


            }
            catch
            {
                ModelState.AddRuleViolations(r.GetRuleViolations());
                return View(r);
            }

        }

        // HTTP GET: /Weights/Delete/1
        public ActionResult Delete(int id)
        {
            int count = 0;
            List<WeightRecord> r = weightRecords.GetWeights(null, id, null, null, "", out count);
            // Retrieve existing weight record

            if (r.Count > 0)
            {
                return View(r[0]);
            }
            else
            {
                return View("NotFound");
            }
        }

        // HTTP POST /Weight/Delete/1
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            int count = 0;
            List<WeightRecord> r = weightRecords.GetWeights(null, id, null, null, "", out count);
            // Retrieve existing weight record
            if (r.Count > 0)
            {
                weightRecords.Delete(r[0].WeightRecordID);
                return View("Deleted");
            }
            else
            {
                return View("NotFound");
            }

        }



    }
    // This should be in a different file
    // Implement AddRuleViolations extension method on the ModelStateDictionary class.
    public static class ControllerHelpers
    {
        public static void AddRuleViolations(this ModelStateDictionary modelState, IEnumerable<RuleViolation> errors)
        {
            foreach (var issue in errors)
            {
                modelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
            }
        }
    }

  
}
