using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace quierobesarte.Common
{
    public class FileHelper
    {
        public static string GetUniuqueFileName(string path, string fileName)
        {
            var maxFileCounter = 0;

            var files = System.IO.Directory.GetFiles(path);

            foreach (var file in files)
            {
                var withoutExtension = Path.GetFileNameWithoutExtension(file);
                int index = withoutExtension.LastIndexOf("(");
                var originalName = withoutExtension;
                if (index > 0)
                    originalName = withoutExtension.Substring(0, index);

                if (fileName.IndexOf(originalName) == 0)
                {
                    var counter = 0;
                    if ((withoutExtension.EndsWith(")") && index > 0))
                    {

                        Int32.TryParse(withoutExtension.Substring(index + 1, withoutExtension.Length - (index + 2)),
                                       out counter);
                    }
                    maxFileCounter = (counter > maxFileCounter) ? counter : maxFileCounter;
                }

            }
            if (maxFileCounter >= 0)
            {
                maxFileCounter++;
                fileName = string.Format("{0}({1}){2}", fileName, maxFileCounter, Path.GetExtension(fileName));
            }
            return fileName;
        }
    }
}