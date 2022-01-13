using System.Drawing;
using WIA;

namespace AppForScanning.Domain.Models
{
    public class Scanner
    {
        public Device Device { get; set; }

        public ImageFile ImageFile { get; set; }

        public string FilePathForSaveScanDocument { get; set; }

        public Image Image { get; set; }
    }
}