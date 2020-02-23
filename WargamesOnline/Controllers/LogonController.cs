using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBEMGlory.Accessors;
using PBEMGlory.Contexts;
using PBEMGlory.Models;
using PBEMGlory.Models.dbModels;

namespace PBEMGlory.Controllers
{
    [AllowAnonymous]
    public class LogonController : Controller
    {
        private CoreContext _coreContext;
        public LogonController(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public IActionResult Index()
        {
            return View("Logon");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        public IActionResult RegisterNewUser(LogonModel logonModel)
        {
            // validate inputs
            if (!string.IsNullOrEmpty(logonModel.UserName) && !string.IsNullOrEmpty(logonModel.Password) && !string.IsNullOrEmpty(logonModel.DisplayName) && !string.IsNullOrEmpty(logonModel.EmailAddress))
            {
                CryptoAccessor cryptoAccessor = new CryptoAccessor();
                // Check username not already taken
                if (_coreContext.Users.FirstOrDefault(x => x.UserName == logonModel.UserName) != default(User))
                {
                    ViewBag.Message = "Sorry username already taken.";
                    return View("Register");
                }
                // Create User
                User user = new User();
                user.Name = logonModel.DisplayName;
                user.UserName = logonModel.UserName;
                user.Salt = cryptoAccessor.CreateSalt();
                user.Hash = cryptoAccessor.CreateHash(logonModel.Password, user.Salt);
                user.EmailAddress = logonModel.EmailAddress;
                // Save new user
                _coreContext.Users.Add(user);
                _coreContext.SaveChanges();
                // Sign Cookie
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, UserAccessor.ClaimsPrincipal(user), new AuthenticationProperties() { IsPersistent = true });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Sorry but one of the required inputs is not filled in.";
                return View("Register");
            }
        }

        public async Task<IActionResult> AttemptLogon(LogonModel logonModel)
        {
            // validate inputs
            if (!string.IsNullOrEmpty(logonModel.UserName) && !string.IsNullOrEmpty(logonModel.Password))
            {
                CryptoAccessor cryptoAccessor = new CryptoAccessor();
                // Find user by username
                User user = _coreContext.Users.FirstOrDefault(x => x.UserName == logonModel.UserName);
                // If no user found with the logon attempts username then refuse logon
                if (user == default(User))
                {
                    // Refuse Logon
                    ViewBag.Message = "Logon Incorrect WTF Cyber Police Informed Woo Woo Woo";
                    return View("Logon");
                }
                // Process to check the hash
                string salt = user.Salt;
                if (cryptoAccessor.CreateHash(logonModel.Password, salt) == user.Hash)
                {
                    // Sign Cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, UserAccessor.ClaimsPrincipal(user), new AuthenticationProperties() { IsPersistent = true });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Refuse Logon
                    ViewBag.Message = "Logon Incorrect WTF Cyber Police Informed Woo Woo Woo";
                    return View("Logon");
                }
            }
            return View();
        }
    }
}