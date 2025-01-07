using LoanCalculatorAPI.Api.Models;
using LoanCalculatorAPI.Common.Models.ResultPattern;
using MediatR;

namespace LoanCalculatorAPI.Api.Finance.ValuateLoan;

public record ValuateLoanQuery(LoanRequest LoanRequest) : IRequest<Result<decimal>>;