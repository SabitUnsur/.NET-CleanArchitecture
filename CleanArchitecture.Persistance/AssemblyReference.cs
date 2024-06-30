using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance
{
    //IEntityConfiguration'ları bulabilmek için CleanArchitecture.Persistance assembly'sini referans olarak kullanabilmek
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
