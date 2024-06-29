using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation
{   
    //bunun amacı, CleanArchitecture.Presentation assembly'sini referans olarak kullanabilmek
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(Assembly).Assembly;
    }
}
