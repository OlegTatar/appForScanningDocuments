using System.Drawing;
using WIA;

namespace AppForScanning.Models
{
    public static class ScanDto
    {
        public static DeviceInfo Device { get; set; }

        public static ImageFile ImageFile { get; set; }

        public static string FilePathForSaveScanDocument { get; set; }

        public static Image Image { get; set; }
    }
}