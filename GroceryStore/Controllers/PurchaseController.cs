using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Controllers
{
    public class PurchaseController : Controller
    {

        GroceryEntities obj = new GroceryEntities();
        
        // GET: Purchase
        public ActionResult PurchaseList()
        {
            return View(obj.Purchases.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Purchase data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Purchases.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("PurchaseList");

        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Purchases where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(Purchase IdToEdit)
        {
            var orignalRecord = (from m in obj.Purchases where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("PurchaseList");

        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(Purchase Id)
        {
            var d = obj.Purchases.Where(x => x.id == Id.id).FirstOrDefault();
            obj.Purchases.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("PurchaseList");
        }

        // POST: Purchase/Delete/5
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
