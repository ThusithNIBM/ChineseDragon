using ChineseDragon.Common.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ChineseDragon.Common
{
    namespace Properties
    {
        public enum APIs
        {
            OrderAPI
        }

        public class CommonAppData
        {
            public static string OrderAPI_token { get; set; }
        }
    }

        namespace Functions
    {
        internal class APIaccess
        {
            public static string GetResult(APIs API, bool isGET, string URL, string JSonParams)
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");

                    string token = null;
                    switch (API)
                    {
                        case APIs.OrderAPI:
                            token = Properties.CommonAppData.OrderAPI_token = (string.IsNullOrWhiteSpace(Properties.CommonAppData.OrderAPI_token) ? ObtainToken(ChineseDragon.Properties.Settings.Default.OrderAPI) : Properties.CommonAppData.OrderAPI_token);
                            break;

                    }

                    client.Headers.Add("Authorization", "bearer " + token);

                    string result = null;

                    if (isGET)
                    {
                        result = client.DownloadString(URL);
                    }
                    else
                    {
                        result = client.UploadString(URL, JSonParams);
                    }

                    return result;
                }
            }
            
            private static string ObtainToken(string API_URL, string Username = "Thusith.virtual@gmail.com", string Password = "Abc@1234")
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues(API_URL + "/token", new NameValueCollection
                    {
                        {
                            "userName",
                            Username
                        },
                        {
                            "password",
                            Password
                        },
                        {
                            "grant_type",
                            "password"
                        }
                    });
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    return JSserializer.Deserialize<ChineseDragon.Models.API_TokenResultDOM>(System.Text.Encoding.UTF8.GetString(response)).access_token;
                }
            }
        }
    }
}