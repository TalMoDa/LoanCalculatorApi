using FluentValidation;
using MediatR;
using LoanCalculatorAPI.Common.Models.ResultPattern;

namespace LoanCalculatorAPI.Pipelines;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IValidator<TRequest>? _validator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ValidationBehavior(IHttpContextAccessor httpContextAccessor, IValidator<TRequest>? validator = null)
    {
        _validator = validator;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.BadRequest(
                validationFailure.ErrorMessage,
                validationFailure.ErrorCode));

        _httpContextAccessor.HttpContext.Items.Add("Errors", errors);

        return (dynamic)errors;
    }
}