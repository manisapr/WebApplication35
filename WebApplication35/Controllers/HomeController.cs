using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication35.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult submit()
        {
            var uname = Request.Form.Get("_uname");
            var phn = Request.Form.Get("_phn");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand com = new SqlCommand("insert into user_auth (ClientCode,User_Email) values ('" + uname + "','" + phn + "')", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter rdr = new SqlDataAdapter(com);
            rdr.Fill(ds);
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}