using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Common;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace quierobesarte.Common
{
    public class QrCodeEngine
    {
        public static string Generate(string path, string weddingId)
        {
            int width = 300;
            string fileName = weddingId + ".png";
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = qrEncoder.Encode("http://" + ConfigurationManager.AppSettings["AppServer"] + "/Uploader/?guid=" + weddingId);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var fs = new FileStream(path + fileName, FileMode.CreateNew))
            {
                var renderer = new WriteableBitmapRenderer(new FixedCodeSize(width, QuietZoneModules.Four), Colors.Black, Colors.White);
                renderer.WriteToStream(qrCode.Matrix, ImageFormatEnum.PNG, fs);

                var image = new Bitmap(Image.FromStream(fs), new Size(new Point(width, width)));
                image.Save(fs, ImageFormat.Png);
            }

            return fileName;
        }
    }



}