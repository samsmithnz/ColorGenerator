using SixLabors.ImageSharp.PixelFormats;

namespace ColorGenerator.Web.Models
{
    public class IndexModel
    {
        public IndexModel(byte[] imageByteArray, List<Rgb24> colors)
        {
            ImageByteArray = imageByteArray;
            Colors = colors;
        }

        public byte[] ImageByteArray { get; set; }
        public List<Rgb24> Colors { get; set; }
    }
}
