using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quierobesarte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Url(string type)
        {
            if(type.ToLower()=="facebook")
            {
                return Redirect("http://goo.gl/RLqYkH"); 
            }
            if (type.ToLower() == "twitter")
            {
                return Redirect("http://goo.gl/Ml0BbI");
            }
            if (type.ToLower() == "vimeo")
            {
                return Redirect("http://goo.gl/XsvDcN");
            }
            return null;

        }



    }
}
