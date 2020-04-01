using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        GroceryEntities obj = new GroceryEntities();

        public ActionResult SaleDetails()
        {
            return View(obj.Sales.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Sale data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Sales.Add(data);
            obj.SaveChanges();
            return RedirectToAction("Create");
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Sales where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(Sale IdToEdit)
        {
            var orignalRecord = (from m in obj.Sales where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("SaleDetails");
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(Sale Id)
        {
            var d = obj.Sales.Where(x => x.id == Id.id).FirstOrDefault();
            obj.Sales.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("SaleDetails");
        }

        // POST: Sale/Delete/5
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
