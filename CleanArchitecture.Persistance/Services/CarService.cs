using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
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
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
           /* Car car = new Car()
            {
                Name = request.Name,
                Model = request.Model,
                EnginePower = request.EnginePower
            };*/

            Car car = _mapper.Map<Car>(request);

            await _carRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            /*await _dbSet.AddAsync(car, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);*/
        }

        public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars =
                await _carRepository
                .GetWhere(p=>p.Name.ToLower().Contains(request.Search.ToLower()))
                .ToPagedListAsync(request.PageNumber,request.PageSize,cancellationToken);
            return cars;
        }
    } 
}
