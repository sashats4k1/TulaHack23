/*using groupChat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace groupChat.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{


        //    return View();
        //}
        [HttpGet]
        public ActionResult Index(WebsiteVistorData vistorDataViewModel)
        {
            vistorDataViewModel = vistorDataViewModel.getClientIPData();
            Networking networking = new Networking();
            string MACAdress = networking.getPhysicalAddress();
            string clientMachineName = networking.getClientMachineName();
            //string getDeviceId = networking.getDeviceId();
            //string getCPUId = networking.getCPUId();
            //string getUUID = networking.getUUID();
            vistorDataViewModel.MacId = MACAdress;
            vistorDataViewModel.ClientMachineName = clientMachineName;
            return View(vistorDataViewModel);
        }
        [HttpPost]
        public JsonResult ajaxSenderUserName(Connection connection)
        {
            var userName = connection.UserName;
            var connectionID = connection.ConnectionID;
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(connectionID))
            {
                FormsAuthenticationTicket ticket =
                   new FormsAuthenticationTicket(1, userName,
                            DateTime.Now, DateTime.Now.AddMinutes(20),
                            true, connectionID, FormsAuthentication.FormsCookiePath);
                string hashcookies = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashcookies)
                {
                    Expires = ticket.Expiration
                };

                Response.Cookies.Add(cookie);
                FormsAuthentication.SetAuthCookie(userName, false);
                return Json(new { IsValid = true });
            }
            else
            {
                return Json(new { IsValid = false });
            }
        }

        public JsonResult getClientIPData()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //string apiUrl = "https://ipinfo.io?token=xxxxxxxxx";
                    string apiUrl = "http://ip-api.com/json";
                    //HTTP GET
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var responseTask = client.GetAsync(apiUrl);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var alldata = readTask.Result;

                        //WebsiteVistorData vistorData = new WebsiteVistorData();
                        var vistorData = Newtonsoft.Json.JsonConvert.DeserializeObject<WebsiteVistorData>(alldata);


                        return Json(new
                        {
                            Data = vistorData
                        }, JsonRequestBehavior.AllowGet);


                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        return Json(new
                        {
                            Data = false
                        }, JsonRequestBehavior.AllowGet);


                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new
                {

                    Data = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //public JsonResult InupProduct(string id, string pname, string pprice)
        //{


*/