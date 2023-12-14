using HaritaSite.Models;
using HaritaSite.Models.Context;
using HaritaSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

using System.Diagnostics;
using System.Drawing;

namespace HaritaSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult ListDrawing()
        {
            var drawing = _dataContext.Drawings.ToList();
            return View(drawing);
        }
        [HttpPost]
        public IActionResult SaveDrawing(Drawing drawing)
        {
            drawing.Statu = true;
            drawing.CreateDate = DateTime.Now.ToUniversalTime();
            _dataContext.Add(drawing);
            _dataContext.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}