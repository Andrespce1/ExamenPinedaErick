using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Examen_PinedaErick.OCR
{
    public class respuesta
    {
        public string language { get; set; }
        public decimal textAngle { get; set; }
        public string orientation { get; set; }
        public region[] regions { get; set; }
        public string modelVersion { get; set; }
    }
}
