using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFebruar
{
    internal class News_Jsons
    {
        /*
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }*/

        public class Class1
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string imagePath { get; set; }
            public string link { get; set; }
            public string date { get; set; }
        }
    }
}
