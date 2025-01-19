using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
//using Pension_Management;
using PensionerMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace PensionerMVC.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "http://localhost:44495/";
        public static string msg;

        [Authorize]
        [HttpGet]
        public async Task<Pensioner> GetPensioner(long aadharid)
        {
            Pensioner p = new Pensioner();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Pensioners/" + aadharid);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<Pensioner>(result);
                }
            }
            return (p);
        }

        [Authorize]

        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(PensionerInput pensionerInput)
        {
            Pensioner p = new Pensioner();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Pensioners/" + pensionerInput.AadharNo);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<Pensioner>(result);
                }
                else
                {

                    msg = "Please Enter Correct Aadhar Number";
                    return RedirectToAction("ErrorPage", pensionerInput);
                }
            }
            if (p.Name != pensionerInput.Name)
            {
                msg = "Please Enter Correct Name";
                return RedirectToAction("ErrorPage", pensionerInput);
            }
            else if (p.DateOfBirth != pensionerInput.DateOfBirth)
            {
                msg = "Please Enter Correct Date of Birth";
                return RedirectToAction("ErrorPage", pensionerInput);
            }
            else if (p.Pan != pensionerInput.Pan)
            {
                msg = "Please Enter Correct PAN Details";
                return RedirectToAction("ErrorPage", pensionerInput);
            }
            else if (p.PensionType != pensionerInput.PensionType)
            {
                msg = "Please Enter Correct Pension Type";
                return RedirectToAction("ErrorPage", pensionerInput);
            }

            msg = "ok";

            if (p.PensionType == "Self")
            {
                p.PensionAmount = ((0.8 * p.SalaryEarned) + p.Allowances);
                if (p.BankType == "Public")
                {
                    p.PensionAmount -= 500;
                }
                else if(p.BankType == "Private")
                {
                    p.PensionAmount -= 550;
                }
                
            }
            else if (p.PensionType == "Family")
            {
                p.PensionAmount = ((0.5 * p.SalaryEarned) + p.Allowances);
                if (p.BankType == "Public")
                {
                    p.PensionAmount -= 500;
                }
                else if (p.BankType == "Private")
                {
                    p.PensionAmount -= 550;
                }
            }
            return RedirectToAction("ResultPage", p);
        }

        [Authorize]
        public IActionResult ErrorPage(PensionerInput pin)
        {
            if (msg == null || msg=="ok")
            {
                return RedirectToAction("Index","Home");
            }

            ViewBag.m = msg.ToString();
            return View();
        }

        [Authorize]
        public IActionResult ResultPage(Pensioner p)
        {
            if(msg==null || msg == "ok")
            {
                return RedirectToAction("Index", "Home");
            }
            msg = null;
            return View(p);
        }
    
    }
}
