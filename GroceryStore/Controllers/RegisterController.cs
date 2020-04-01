using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        GroceryEntities obj = new GroceryEntities();

        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-7U8UBCP\\SQLEXPRESS;Initial Catalog=Grocery;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;

        public ActionResult RegisterList()
        {
            return View(obj.Registers.ToList());
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Confirmation()
        {
            return View();
        }

        //CustomerLogin
        public ActionResult CustomerLogin()
        {
            return View();
        }

        public ActionResult CustomerDashboard()
        {
            return View();
        }

        public ActionResult Invalid()
        {
            return View();
        }




        public ActionResult LoginPass(CustomerLogin cl) {
            String qry = "select * from Register where Email='"+cl.CustomerName+"' and Password='"+cl.CustomerPassword+"'";
            DataTable tbl = new DataTable();
            tbl = srchRecord(qry);
            if (tbl.Rows.Count > 0)
            {
                return View("CustomerDashboard");
            }
            else {
                return View("Invalid");
            }

        }


        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();

            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }


        // POST: Register/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Register IdData)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Registers.Add(IdData);
            obj.SaveChanges();
            return RedirectToAction("Confirmation");
        }


        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(Register Id)
        {
            var d = obj.Registers.Where(x => x.id == Id.id).FirstOrDefault();
            obj.Registers.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("RegisterList");
        }

        // POST: Register/Delete/5
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
