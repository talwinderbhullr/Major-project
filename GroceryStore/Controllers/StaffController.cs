using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        GroceryEntities obj = new GroceryEntities();

        public ActionResult StaffDetails()
        {
            return View(obj.staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] staff IdData)
        {
            if (!ModelState.IsValid)
                return View();
            obj.staffs.Add(IdData);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("StaffDetails");
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.staffs where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(staff IdToEdit)
        {
            var orignalRecord = (from m in obj.staffs where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("StaffDetails");

        }

        // GET: Staff/Delete/5
        public ActionResult Delete(staff Id)
        {
            var d = obj.staffs.Where(x => x.id == Id.id).FirstOrDefault();
            obj.staffs.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("StaffDetails");
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
