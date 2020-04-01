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
    public class HomeController : Controller
    {
        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-7U8UBCP\\SQLEXPRESS;Initial Catalog=Grocery;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Incorrect()
        {
            return View();
        }

        public void QueryRecord(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
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


        public ActionResult FeedPass(Feed adm)
        {
            String qry = "insert into FeedBack(Name,Contact,Email,Message) values('"+adm.FeedName+"','"+adm.FeedContact+"','"+adm.FeedEmail+"','"+adm.FeedMsg+"')";
            QueryRecord(qry);
            return View("Thanks");
        }



            public ActionResult LoginPass(Admin adm) {
            String qry = "select * from AdminTable where AdminName='" + adm.AdminName + "' and AdminPassword='" + adm.AdminPassword + "'";
            DataTable tbl = new DataTable();
            tbl = srchRecord(qry);
            if (tbl.Rows.Count>0)
            {
                return View("Dashboard");

            }
            else {
                return View("Incorrect");
            }
        }


        public ActionResult Thanks()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}