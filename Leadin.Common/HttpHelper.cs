using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Leadin.Common
{
    public class HttpHelper
    {


        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Post(string postData, string url)
        {
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //httpContent.Headers.Add("channelId", channelId);


            var httpClient = new HttpClient();
            var responseJson = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            return responseJson;
        }



        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            //创建一个HTTP请求
            WebRequest request = WebRequest.Create(url);
            //设置POST请求
            request.Method = "GET";
            //请求数据内容类型
            request.ContentType = "application/x-www-form-urlencoded";
            //创建一个HTTP应答
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFormServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFormServer;
        }

        /// <summary>
        /// 把JSON字符串还原为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="szJson">JSON字符串</param>
        /// <returns>对象实体</returns>
        public static T ParseFormJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
                return (T)dcj.ReadObject(ms);
            }
        }
    }
}
