using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace quierobesarte.Common
{
    public class Security
    {
        public static ActionResult ActionResult(string id, Action action, ActionResult succesAction)
        {
          

            if (string.IsNullOrWhiteSpace(id))
                return new HttpNotFoundResult("The 'wedding id' not found.");
            IEnumerable<string> availablesWeddings;

            using (var db = new db498802376Entities())
            {
                availablesWeddings = db.weddings.Select(w => w.id).ToArray();
            }

            if ((availablesWeddings != null && availablesWeddings.Contains(id)))
            {
                action();
                return succesAction;
            }
            else
            {
                return new HttpNotFoundResult("The 'wedding id' invalid.");
            }
        }
    }
}