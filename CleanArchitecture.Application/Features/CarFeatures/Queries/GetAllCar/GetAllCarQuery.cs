using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed record GetAllCarQuery(
      int PageNumber=1,
      int PageSize = 10,
      string Search="") : IRequest<PaginationResult<Car>>
    {
    }
}
