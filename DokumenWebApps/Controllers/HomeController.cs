using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DokumenWebApps.Models;

namespace DokumenWebApps.Controllers
{
    //homepage
    public class HomeController : Controller
    {
        //tambah keterangan dari erick
        public IActionResult Index()
        {
            return View();
        }

        //tambah rufus
        public IActionResult About()
        {
            ViewBag.Nama = "Rufus";
            return View();
        }

        public IActionResult Contact()
        {
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
