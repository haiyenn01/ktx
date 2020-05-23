using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlurasightLogin.Controllers
{
    public class AccountController : Controller 
    {
        public UserManager<ExtendedUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<ExtendedUser>>();
        public SignInManager<ExtendedUser, string> SignInManager => HttpContext.GetOwinContext().Get<SignInManager<ExtendedUser, string>>();
        
        public ActionResult LoginAsync()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var resetUrl=Url.Action("PasswordReset", "Account", new { userid = user.Id, token = token }, Request.Url.Scheme);
                string content = System.IO.File.ReadAllText(Server.MapPath("Email.cshtml"));
                content = content.Replace("{{FullName}}", user.FullName);
                content = content.Replace("{{URL}}", resetUrl);
                 await UserManager.SendEmailAsync(user.Id, "Password Reset", $"Use link to reset password : {resetUrl}");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> LoginAsync(LoginModel model)
        {
          var signInStatus= await SignInManager.PasswordSignInAsync(model.Username, model.Password, true,true);
            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("ChooseProvider");
                default:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }  
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var identityUser = await UserManager.FindByNameAsync(model.Username);
            if (identityUser != null)
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                return View();
            }
            var user = new ExtendedUser
            {
                FullName = model.FullName,
                UserName = model.Username,
                Email = model.Email  
            };
            user.Addresses.Add(new Address { AddressLine = model.AddressLine,Country = model.Country,UserId = user.Id });
            var identityResult = await UserManager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
               var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
               var confirmUrl =  Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = token }, Request.Url.Scheme);
               
                await UserManager.SendEmailAsync(user.Id, "Email Confirmation ", $"Vui long xac thuc email de tao tai khoan tai <a href='{ confirmUrl }'>day</a>");
                
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(" ", identityResult.Errors.FirstOrDefault());
            return View(model);
        }

        public async  Task< ActionResult> ConfirmEmail(string userid,string token)
        {
            var identityResult = await UserManager.ConfirmEmailAsync(userid, token);
            if(!identityResult.Succeeded)
            {
                return View("Error");
            }
              return RedirectToAction("Index", "Home");
        }
        public ActionResult PasswordReset(string userid,string token)
        {
            return View(new PasswordResetModel { userid = userid, token = token });
        }
        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordResetModel model)
        {
            var identityResult = await UserManager.ResetPasswordAsync(model.userid, model.token, model.password);
            if (!identityResult.Succeeded)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }
    }

    public class PasswordResetModel
    {
        public string userid { get; set; }
        public string token { get; set; }
        public string password { get; set; }
    }

    public class ForgotPasswordModel
    {
        public string Username { get; set; }
    }


    public class RegisterModel { 
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}