using DemoWEBAPI_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWEBAPI_Project.Controllers
{
    public class SampleDataController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage LoadJsonMessage()
        {
            try
            {
                var filepath = "C:/Users/admin/Documents/visual studio 2015/Projects/DemoWEBAPI_Project/DemoWEBAPI_Project/SampleData/SampleData.json";
                var response = Request.CreateResponse<string>(SerializeJson(filepath));
                return response;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        private string SerializeJson(string filepath)
        {
            string json = string.Empty;
            if(filepath!= null)
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    json = reader.ReadToEnd();
                    return json;
                }
            }
            return json;
            
        }
    }
}
