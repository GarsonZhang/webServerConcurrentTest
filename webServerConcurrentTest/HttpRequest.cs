using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace webServerConcurrentTest
{
    public class HttpRequest
    {
        public static string Post(string url, string data)
        {
            string returnData = null;
            try
            {
                string strURL = url;
                HttpWebRequest request;
                request = (System.Net.HttpWebRequest)HttpWebRequest.Create(strURL);
                request.Proxy = WebRequest.GetSystemWebProxy();
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                string paraUrlCoded = data;
                byte[] payload;
                payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.Stream s;
                s = response.GetResponseStream();

                string StrDate = "";
                string strValue = "";
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate + "\r\n";
                }
                returnData = strValue;
            }
            catch
            {
                return "";
            }
            return returnData.Trim() + "\n";
        }

        public static CallMsg PostEx(string url, string data)
        {
            CallMsg msg = new CallMsg();
            try
            {
                msg.beginTime = DateTime.Now;
                string strURL = url;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strURL);
                request.Proxy = WebRequest.GetSystemWebProxy();
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                string paraUrlCoded = data;
                byte[] payload = Encoding.UTF8.GetBytes(paraUrlCoded);
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)//相应成功  
                {
                    msg.endTime = DateTime.Now;
                    msg.ResponseTime = (msg.endTime - msg.beginTime).TotalMilliseconds;//获取相应时间   

                    System.IO.Stream s = response.GetResponseStream();

                    string StrDate = "";
                    string strValue = "";
                    StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                    while ((StrDate = Reader.ReadLine()) != null)
                    {
                        strValue += StrDate + "\r\n";
                    }
                    msg.ResponseData = strValue.Trim();
                    msg.Status = true;
                    response.Close();//关闭文件流  
                }
                else
                {
                    msg.Status = false;
                    msg.ResponseData = "500,无法连接到远程服务器";
                }
            }
            catch (Exception ex)
            {
                msg.ResponseData = "发生异常：" + ex.ToString();
                msg.Status = false;
            }

            return msg;
        }

        public async static Task<CallMsg> SysnPostEx(string url, string json)
        {
            // Clear text of Output textbox  
            CallMsg msg = new CallMsg();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        msg.beginTime = DateTime.Now;
                        HttpResponseMessage wcfResponse = await httpClient.PostAsync(url, content);

                        msg.endTime = DateTime.Now;
                        msg.ResponseTime = (msg.endTime - msg.beginTime).TotalMilliseconds;//获取相应时间   
                        if (wcfResponse.StatusCode == HttpStatusCode.OK)//相应成功  
                        {

                            string str = wcfResponse.Content.ReadAsStringAsync().Result;
                            msg.ResponseData = str;
                            msg.Status = true;
                        }
                        else
                        {
                            msg.Status = false;
                            msg.ResponseData = "500,无法连接到远程服务器";
                        }


                        
                        //await DisplayTextResult(wcfResponse, OutputField);
                    }
                }
                catch (Exception ex)
                {
                    //NotifyUser(ex.Message);
                    msg.ResponseData = "发生异常：" + ex.ToString();
                    msg.Status = false;
                }
                finally
                {

                }

                return msg;
            }

        }


        public class CallMsg
        {
            public bool Status { get; set; }
            public string ResponseData { get; set; }
            public double ResponseTime { get; set; }

            public DateTime beginTime { get; set; }
            public DateTime endTime { get; set; }
            public CallMsg()
            {
                Status = false;
            }
        }

        public static string PostXml(string url, string strPost)
        {

            var request = WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "text/xml";
            request.Headers.Add("charset:utf-8");
            var encoding = Encoding.GetEncoding("utf-8");
            if (strPost != null)
            {
                byte[] buffer = encoding.GetBytes(strPost);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
            }
            else
            {
                request.ContentLength = 0;
            }
            using (HttpWebResponse wr = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(wr.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }



        public async static void SysnPost(string url, string json)
        {
            // Clear text of Output textbox  

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {

                        HttpResponseMessage wcfResponse = await httpClient.PostAsync(url, content);

                        //string str = wcfResponse.Content.ReadAsStringAsync().Result;
                        //await DisplayTextResult(wcfResponse, OutputField);
                    }
                }
                catch //(Exception ex)
                {
                    //NotifyUser(ex.Message);
                }
                finally
                {

                }
            }

        }

        public static string Get(string URL)
        {
            String ReCode = string.Empty;
            try
            {
                HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();
                wNetr.ContentType = "text/html";
                wNetr.Method = "Get";
                Stream Streams = wNetp.GetResponseStream();
                StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);
                ReCode = Reads.ReadToEnd();

                //封闭临时不实用的资料 
                Reads.Dispose();
                Streams.Dispose();
                wNetp.Close();
            }
            catch (Exception ex) { return ex.Message; }

            return ReCode;
        }
    }
}
