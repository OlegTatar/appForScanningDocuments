using System;

namespace AppForScanning.Domain.Models
{
    public class ScanDocument
    {
        public string FileName { get; set; }

        public DateTime DateCreate { get; set; }

        public long SizeInKiloBytes { get; set; }
    }
}