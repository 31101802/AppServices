using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace quierobesarte.Common
{
    public class Utils
    {
        public static long GenerateUnique()
        {
            return DateTime.Now.Ticks;
        }

        public static string GetUser()
        {
            return System.Web.HttpContext.Current.Request.Headers["App-User"];
        }

        public static void LogRequestHeaders(string method)
        {

            var device = System.Web.HttpContext.Current.Request.Headers["App-Device"];
            decimal version;
            
            var versionHeader = HttpContext.Current.Request.Headers["App-Version"];

            const NumberStyles style = NumberStyles.AllowDecimalPoint;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            if (Decimal.TryParse(versionHeader, style, culture, out version)) ;

            var user = GetUser();

            var hasCorrectVersion = IsAcceptedVersion(version) || HttpContext.Current.Request.Headers["X-Requested-With"]=="XMLHttpRequest";


            var status = "VersionOk";
            //Commented this line
            //if (System.Web.HttpContext.Current.Request.Headers["User-Agent"] != null)
            //{
            //    hasCorrectVersion=  true;
            //}

            if (!hasCorrectVersion)
            {
                status = "OldVersion";
            }
           
            
            using (var db = new db498802376Entities())
            {
                db.logs.Add(new log()
                                {
                                    date = DateTime.Now,
                                    device = device,
                                    version = version.ToString(),
                                    method = method,
                                    user = user,
                                    status = status

                                });

                db.SaveChanges();
            }

            if(!hasCorrectVersion)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UpgradeRequired));
                
            }
        }

        public static bool IsAcceptedVersion(decimal version)
        {
            return (version >= 1);
        }
    }
}