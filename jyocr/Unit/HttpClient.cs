using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace jyocr.Unit
{
    class HttpClient
    {
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            // 直接确认，否则打不开
            return true;
        }

        public static string Post(string postData, string url, int timeout = 30, string token = "", string contentType = "application/x-www-form-urlencoded")
        {
            System.GC.Collect(); // 垃圾回收，回收没有正常关闭的http连接
            string result = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                // 设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                // 设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                // 设置POST的数据类型和长度
                request.ContentType = contentType;
                if (token != "")
                    request.Headers.Add("Token", token);

                byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = data.Length;

                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                // 获取服务端返回
                response = (HttpWebResponse)request.GetResponse();
                // 获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                System.Threading.Thread.ResetAbort();
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (response != null)
                    response.Close();

                if (request != null)
                    request.Abort();
            }

            return result;
        }
    }
}
