using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Search.Models
{
    public class ServiceSearch
    {
        public string formatText(string cadena)
        {
            string format;
            format = cadena.Replace(' ', '+');
            return format;
        }

        public string getJSON(string artistSearch)
        {

            string strUrl = String.Format("https://itunes.apple.com/search?term=" + artistSearch);
            WebRequest requestObjGet = WebRequest.Create(strUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
            string strResult = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strResult = sr.ReadToEnd();
                sr.Close();
            }

            return strResult;
        }

        public Resultado readingJSON(string fileTxt)
        {
            var rs = JsonConvert.DeserializeObject<Resultado>(fileTxt);
            return rs;
        }

    }
}