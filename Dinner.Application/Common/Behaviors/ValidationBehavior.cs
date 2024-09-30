using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Errors;
using FluentValidation;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse: IOneOf
       
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator == null)
            {
                return await next();
                
            }
            var validationRes = await _validator.ValidateAsync(request, cancellationToken);
            //before the handler
            if (validationRes.IsValid)
            {
                return await next();
            }
            else
            {
                var errs = validationRes.Errors;
                ApiResponse api = new ApiResponse(400);
                foreach (var error in errs)
                {
                    api.Message += "," + error.ErrorMessage;
                }
                return (dynamic)api;
            }
        }
    }
}
