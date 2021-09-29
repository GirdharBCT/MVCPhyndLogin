using Microsoft.AspNetCore.Mvc;
using MVCPhyndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace MVCPhyndLogin.Controllers
{
    public class mvcLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Autherize(LoginCred loginCred)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LoginCred>("authenticate", loginCred);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    loginCred.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", loginCred);
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("Index", "mvcLogin"); ;

        }
    }
}
