using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Behaviors
{
    //Validation Kurallarını kontrol edip hata mesajlarını döndüren sınıf
    //bu sınıf ne işe yarar? ValidationBehavior sınıfı, MediatR pipeline'ına bir davranış ekler. Bu davranış, bir isteği işlemek için bir işleyici çağrıldığında, isteğin doğrulanmasını sağlar.
    public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> 
        where TRequest:class,IRequest<TResponse> //TRequest sınıfı IRequest interface'inden türemiş olmalı
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any()) 
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
