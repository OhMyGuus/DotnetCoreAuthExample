using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleExample.Helpers;
using SimpleExample.Models;
using SimpleExample.Repositories;

namespace SimpleExample.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "This page is only for the role Admin.";

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Contact()
        {
           var user = await User.GetUserAsync(_userRepository);

            ViewData["Message"] = $"This page is only for logged with the user {user.Username}";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
