using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkytapApi
{
    public class Client
    {
        public string UserName { get; private set; }
        public string Token { get; private set; }
        public string BaseUrl { get; private set; }
        public Client(string username, string token)
        {
            UserName = username;
            Token = token;
            BaseUrl = ConfigurationManager.AppSettings["SkyTapApiUrl"];
        }
        public HttpWebRequest BuildWebRequest(string address)
        {
            var request = (HttpWebRequest)WebRequest.Create(address);
            request.PreAuthenticate = true;
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequested;
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.3) Gecko/20090824 Firefox/3.5.3 (.NET CLR 4.0.20506)";
            var token = String.Format("{0}:{1}", UserName, Token);
            request.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(token));
            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            return request;
        }

        public List<Configuration> GetConfigurations()
        {
            var url = BaseUrl + "/configurations";
            var request = BuildWebRequest(url);
            List<Configuration> configurations = new List<Configuration>();
            request.Method = "GET";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XElement configurationsXml;
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        configurationsXml = XElement.Parse(reader.ReadToEnd());
                    }
                    configurations = configurationsXml
                        .Elements("configuration")
                        .Select(x => new Configuration()
                        {
                            Id = int.Parse(x.Element("id").Value),
                            Name = x.Element("name").Value,
                            Url = x.Element("url").Value,
                            Error = x.Element("error").Value,
                        
                        }).ToList();
                }
                else
                {
                    throw new Exception(string.Format("Error in response from API: {0} {1}", response.StatusCode, response.StatusDescription));
                }
            }
            return configurations;
        }
        public Configuration GetConfiguration(int configurationId)
        {
            var url = BaseUrl + string.Format("/configurations/{0}", configurationId);
            var request = BuildWebRequest(url);
            Configuration configuration;
            request.Method = "GET";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XElement configurationXml;
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        configurationXml = XElement.Parse(reader.ReadToEnd());
                    }
                    configuration = new Configuration()
                        {
                            Id = int.Parse(configurationXml.Element("id").Value),
                            Name = configurationXml.Element("name").Value,
                            Url = configurationXml.Element("url").Value,
                            Error = configurationXml.Element("error").Value,
                            RunState = configurationXml.Element("runstate").Value
                        };
                }
                else
                {
                    throw new Exception(string.Format("Error in response from API: {0} {1}", response.StatusCode, response.StatusDescription));
                }
            }
            return configuration;
        }

        public bool SetConfigurationState(int configurationId, string runstate)
        {
            var url = BaseUrl + string.Format("/configurations/{0}?runstate={1}", configurationId, runstate);
            var request = BuildWebRequest(url);
            Configuration configuration;
            request.Method = "PUT";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("Error in response from API: {0} {1}", response.StatusCode, response.StatusDescription));
                }
            }
        }
    }
}
