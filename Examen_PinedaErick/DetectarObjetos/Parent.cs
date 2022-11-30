using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Examen_PinedaErick.DetectarObjetos
{
    public class Parent
    {
        public Parent parent { get; set; }
        public string Object { get; set; }
        public string confidence { get; set; }
    }
}
