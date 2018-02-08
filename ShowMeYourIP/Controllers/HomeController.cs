using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using ShowMeYourIP.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ShowMeYourIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public HomeController(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                string ipstring = ip.ToString();

                ViewData["RemoteIP"] = ipstring;
            }
            catch (Exception ex)
            {
                ViewData["Remote-IP"] = ex.Message;
            }
            string CompanyIP = "还没收到IP联系";
            try
            {
                CompanyIP = _memoryCache.Get("CompanyIP").ToString();
                ViewData["CompanyIP"] = CompanyIP;
            }
            catch (Exception ex)
            {
                ViewData["CompanyIP"] = CompanyIP;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact(int id)
        {
            if (id == 7788)
            {
                var ip = Request.HttpContext.Connection.RemoteIpAddress;
                try
                {
                    string CompanyIP = ip.ToString();
                    DateTime now = DateTime.Now;
                    //ViewData["Message"] = "Your contact page.";
                    CompanyIP = _memoryCache.Set("CompanyIP", CompanyIP +"在"+ now.ToString()+"更新");
                    ViewData["CompanyIP"] = CompanyIP;
                }
                catch (Exception ex)
                {
                    ViewData["CompanyIP"] = ex.Message;
                }
            }
            else
            {
                ViewData["CompanyIP"] = "这不是你看到的。";
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region function
        //private string ShowIP()
        //{
        //    //string userIP;
        //    //// HttpRequest Request = HttpContext.Current.Request;  
        //    //HttpRequest Request = HttpContext.Current.Request.UserHostAddress;  // 如果使用代理，获取真实IP  
        //    //if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
        //    //    userIP = Request.ServerVariables["REMOTE_ADDR"];
        //    //else
        //    //    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    //if (userIP == null || userIP == "")
        //    //    userIP = Request.UserHostAddress;
        //    //return userIP;
        //}
        #endregion
    }
}
