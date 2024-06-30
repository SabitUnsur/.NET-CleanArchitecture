using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public sealed class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}
