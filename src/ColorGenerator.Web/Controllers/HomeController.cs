using ColorGenerator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Diagnostics;

namespace ColorGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using Image image = Image.Load(Environment.CurrentDirectory + "/wwwroot/images/PuzzlePieces.jpg");
            using (MemoryStream ms = new MemoryStream())
            {
                IImageEncoder encoder = new JpegEncoder();
                image.Save(ms, encoder);
                return View(ms.ToArray());
            }
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