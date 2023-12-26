using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Reflection
{
    internal class Class
    {
        public Class() { }
        public Class(int i) { }
        public Class(double d) { }

        public int Plus(int x, int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }

        [MyAttribute("Property1 attribute description")]
        public string Property1 { get; set; }
        public int Property2 { get; set; }

        [MyAttribute("Property3 attribute description")]
        public double Property3 { get; private set; }

        public int field1;
        public float field2;
    }
}
