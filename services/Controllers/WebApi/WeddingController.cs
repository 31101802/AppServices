using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using quierobesarte.Common;
using quierobesarte.Models;

namespace quierobesarte.Controllers.WebApi
{
    public class WeddingController : ApiController
    {
        public WeddingDto Get(string id)
        {

            id = HttpUtility.UrlDecode(id);
            Utils.LogRequestHeaders("WeddingController-Get");
         


            WeddingDto wedding = null;
            using (var db = new db498802376Entities())
            {
                var result = db.weddings.SingleOrDefault(w => w.id == id);
                if (result != null)
                {
                    wedding = new WeddingDto()
                               {
                                   Id = id,
                                   Name = result.name,
                                   Date = result.date.ToShortTimeString(),
                                   IsActive = result.active != null && result.active.Value

                               };
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
            }

          
            

            return wedding;
        }
    }
}
