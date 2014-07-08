using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics101
{
    public class Car<T>
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public T Engine { get; set; }
    }

    public class V8
    {
        public V8()
        {
            HorsePower = 300;
        }

        public int HorsePower { get; set; }
    }
}
