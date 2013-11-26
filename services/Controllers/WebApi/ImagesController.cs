using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using quierobesarte.Common;
using quierobesarte.Models;

namespace quierobesarte.Controllers
{
    public class ImagesController : ApiController
    {
        // GET api/images
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/images/5
        public IEnumerable<ImageDto> Get(string id, int page, int numItems)
        {
            id = HttpUtility.UrlDecode(id);
            var data = new List<ImageDto>();
            Utils.LogRequestHeaders("ImagesController-Get");
            using (var db = new db498802376Entities())
            {
                string weddingId;
                var wedding = db.weddings.SingleOrDefault(w => w.id == id);
                if (wedding != null)
                {
                    weddingId = wedding.id;
                }

                data.AddRange(db.wedding_image.Where(w => w.wedding_id == id).OrderByDescending(w => w.created).Skip(page * numItems).Take(numItems)
                    .Select(image => new ImageDto
                    {
                        originalPath = HostingEnvironment.ApplicationVirtualPath + "uploads/" + image.name,
                        thumbnailPath = HostingEnvironment.ApplicationVirtualPath + "uploads/Thumbnail/" + image.name,
                        created = image.created,
                        id = image.id


                    }));
            }

            return data;
        }

        // POST api/images
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // PUT api/images/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // DELETE api/images/5
        public void Delete(int id)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }
    }
}
