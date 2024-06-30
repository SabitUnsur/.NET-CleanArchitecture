using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services
{
    public sealed class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Car> _dbSet;

        public CarService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = new Car()
            {
                Name = request.Name,
                Model = request.Model,
                EnginePower = request.EnginePower
            };

            await _dbSet.AddAsync(car, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }


    }
}
