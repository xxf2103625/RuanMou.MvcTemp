using RuanMou.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RuanMou.MvcTemp.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository userRepository;
        /// <summary>
        /// autofac自动注入,及自动释放
        /// </summary>
        /// <param name="_userRepository"></param>
        public HomeController(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}