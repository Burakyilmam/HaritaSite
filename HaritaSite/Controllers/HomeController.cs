using HaritaSite.Models;
using HaritaSite.Models.Context;
using HaritaSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (drawing.Type == "Point")
            {
                string[] coordinates = drawing.Coordinates.Split(',');
                double x = double.Parse(coordinates[0]);
                double y = double.Parse(coordinates[1]);

                drawing.Shape = new NetTopologySuite.Geometries.Point(x, y) { SRID = 4326 };
            }
            _dataContext.Add(drawing);
            _dataContext.SaveChanges();

            return RedirectToAction("Home");
        }

    }
}