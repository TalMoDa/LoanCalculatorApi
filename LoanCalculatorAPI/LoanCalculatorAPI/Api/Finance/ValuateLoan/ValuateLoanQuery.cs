using LoanCalculatorAPI.Common.Models.ResultPattern;
using MediatR;

namespace LoanCalculatorAPI.Api.Finance.ValuateLoan;

public record ValuateLoanQuery(
    decimal LoanAmount,
    int LoanPeriodInMonths,
    Guid? ClientId)
    : IRequest<Result<decimal>>;