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
            int divisors = 2;
            int step = 255 / divisors;
            List<Rgb24> colors = new();
            //loop in 3 separate for loops
            for (int r = 0; r <= 255; r += step)
            {
                for (int g = 0; g <= 255; g += step)
                {
                    for (int b = 0; b <= 255; b += step)
                    {
                        colors.Add(new Rgb24((byte)r, (byte)g, (byte)b));
                    }
                }
            }

            //Create the image with the target width and height
            Image<Rgb24> newImage = new(500, 10);
            //Add each pixel
            int index = 0;
            int imageWidth = 500 / colors.Count;
            for (int x = 0; x < 500; x++)
            {
                if (imageWidth * (index + 1) < x)
                {
                    index++;
                }
                for (int y = 0; y < 10; y++)
                {
                    if (index > colors.Count - 1)
                    {
                        index = colors.Count - 1;
                    }
                    newImage[x, y] = colors[index];
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