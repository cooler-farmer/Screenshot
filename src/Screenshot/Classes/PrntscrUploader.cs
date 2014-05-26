using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Screenshot.Classes
{
    class PrntscrUploader
    {
        public static string Upload(string imagePath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prntscr.com/upload.php");
            request.KeepAlive = true;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Headers.Add("Origin", @"http://prntscr.com");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
            request.ContentType = "multipart/form-data; boundary=----WebKitFormBoundaryiw0VC86AStQHQ8t4";
            request.Referer = "http://prntscr.com/";
            request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
            request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;

/*            const string body = @"------WebKitFormBoundaryABv72PGVVhIt2Ajy
Content-Disposition: form-data; name=""image""; filename=""Screenshot.png""
Content-Type: image/png
 
<!>Screenshot.png<!>
------WebKitFormBoundaryABv72PGVVhIt2Ajy--
";*/

            string body = @"------WebKitFormBoundaryiw0VC86AStQHQ8t4
Content-Disposition: form-data; name=""image""; filename=""" + imagePath + @"""
Content-Type: image/png

<!>" + imagePath + @"<!>
------WebKitFormBoundaryiw0VC86AStQHQ8t4--
";

            WriteMultipartBodyToRequest(request, body);
            string resp = ReadResponse(request);
            File.Delete("upload.png");
            return resp;
        }

        private static void WriteMultipartBodyToRequest(HttpWebRequest request, string body)
        {
            string[] multiparts = Regex.Split(body, @"<!>");
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                foreach (string part in multiparts)
                {
                    if (File.Exists(part))
                    {
                        bytes = File.ReadAllBytes(part);
                    }
                    else
                    {
                        bytes = System.Text.Encoding.UTF8.GetBytes(part.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"));
                    }

                    ms.Write(bytes, 0, bytes.Length);
                }

                request.ContentLength = ms.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    ms.WriteTo(stream);
                }
            }
        }

        private static string ReadResponse(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                Stream streamToRead = responseStream;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                }

                using (StreamReader streamReader = new StreamReader(streamToRead, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
