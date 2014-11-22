﻿namespace Crm.Admin.Controllers
 {
     using System.Web.Mvc;
     using System.Web.Security;
     using Models;

     public class AuthenticationController : Controller
     {
         //
         // GET: /Authentication/

         [HttpGet]
         public ActionResult Login()
         {
             return View(new LoginModel());
         }

         [HttpPost]
         public ActionResult Login(LoginModel model)
         {
             if (!ModelState.IsValid)
                 return View(model);

             var user = model.Logon();
             if (user != null)
             {
                 FormsAuthentication.RedirectFromLoginPage(user.Login, model.Remember);
                 return null;
             }

             ModelState.AddModelError(string.Empty, "Invalid login or password.");
             return View(model);
         }
     }
 }
