﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using TaskManagementSystem.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private DataContext _context = new DataContext();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var oldManagerUser = _context.ManagerUsers.FirstOrDefault(i => i.Username == model.Username || i.Email == model.Email);
                if (oldManagerUser == null)
                {
                    var oldWorkerUser = _context.WorkerUsers.FirstOrDefault(i => i.Username == model.Username || i.Email == model.Email);
                    if (oldWorkerUser == null)
                    {
                        if (model.IsManager)
                        {
                            ManagerUser user = new ManagerUser()
                            {
                                FullName = model.FullName,
                                Username = model.Username,
                                Email = model.Email,
                                Password = Crypto.HashPassword(model.Password),
                                RegisteredDate = DateTime.Now,
                            };
                            _context.ManagerUsers.Add(user);
                            _context.SaveChanges();
                        }
                        else
                        {
                            WorkerUser user = new WorkerUser()
                            {
                                FullName = model.FullName,
                                Username = model.Username,
                                Email = model.Email,
                                Password = Crypto.HashPassword(model.Password),
                                RegisteredDate = DateTime.Now,
                            };
                            _context.WorkerUsers.Add(user);
                            _context.SaveChanges();
                        }

                        return RedirectToAction("Login");
                    }
                }
                ModelState.AddModelError("", "Username or email is already registered");
            }
            return View(model);
        }

        private string returnUrl;

        [HttpGet]
        public ActionResult Login()
        {
            returnUrl = Request.Params["returnUrl"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var oldManagerUser = _context.ManagerUsers.FirstOrDefault(i => i.Email == model.Email);
                if (oldManagerUser != null)
                {
                    if (Crypto.VerifyHashedPassword(oldManagerUser.Password, model.Password))
                    {
                        //FormsAuthentication.SetAuthCookie(oldManagerUser.Id.ToString(), model.RememberMe);
                        if (model.RememberMe)
                        {
                            Session.Timeout = 1440;
                            Session["AuthToken"] = oldManagerUser.Id;
                        }

                        if (String.IsNullOrEmpty(returnUrl))
                            return RedirectToAction("Index", "Tasks");
                        // Take a look here
                        return RedirectToAction("Dashboard", "Manager");
                    }
                }
                var oldWorkerUser = _context.WorkerUsers.FirstOrDefault(i => i.Email == model.Email);
                if (oldWorkerUser != null)
                {
                    if (Crypto.VerifyHashedPassword(oldWorkerUser.Password, model.Password))
                    {
                        if (model.RememberMe)
                        {
                            Session.Timeout = 1440;
                            Session["AuthToken"] = oldWorkerUser.Id;
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Remove("AuthToken");
            return RedirectToAction("Index", "Home");
        }
    }
}