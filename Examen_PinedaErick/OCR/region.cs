using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_PinedaErick.OCR
{
    public class region
    {
        public string boundingBox { get; set; }
        public line[] lines { get; set; }
    }
}
