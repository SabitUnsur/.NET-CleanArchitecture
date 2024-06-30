using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Car : Entity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int EnginePower { get; set; }
    }
}
