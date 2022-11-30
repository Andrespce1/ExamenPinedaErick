using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_PinedaErick.DetectarObjetos

{
    public class @object
    {
        public Rectangle rectangle { get; set; }
        public string Object { get; set; }
        public double confidence { get; set; }
        public Parent parent { get; set; }

    }
}
