using ColorGenerator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
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
            //Create the image with the target width and height
            Image<Rgb24> newImage = new(500, 10);
            //Add each pixel
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    newImage[i, j] = new Rgb24(0, 0, 255);
                }
            }

            //convert the image to a byte array and return it to the client
            using Image image = newImage;// Image.Load(Environment.CurrentDirectory + "/wwwroot/images/PuzzlePieces.jpg");
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