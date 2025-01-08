/*
 * Loan Calculator Assigment API
 *
 * This is a Loan Calculator API which will have a finance related operations endpoints such as calculate loan, calculate interest etc.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel.DataAnnotations;
using LoanCalculatorAPI.Api.Finance.ValuateLoan;
using LoanCalculatorAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LoanCalculatorAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public sealed class FinanceApiController(IMediator mediator) : AppBaseController
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>This endpoint is used to calculate a loan by given loan request.</remarks>
        /// <param name="loanAmount">The loan amount requested by the customer.</param>
        /// <param name="loanPeriodInMonths">The loan period in months requested by the customer.</param>
        /// <param name="clientId">The client id of the customer who is requesting the loan we will use this to calculate the loan based on the customer information.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/finance/loan")]
        [ValidateModelState]
        [SwaggerOperation("ValuateLoan")]
        [SwaggerResponse(statusCode: 200, type: typeof(decimal), description: "successful operation")]
        public async Task<IActionResult> ValuateLoan([FromQuery (Name = "loanAmount")][Required()]decimal loanAmount, [FromQuery (Name = "loanPeriodInMonths")][Required()]int loanPeriodInMonths, [FromQuery (Name = "clientId")]Guid? clientId, CancellationToken cancellationToken)
        {
            var query = new ValuateLoanQuery(
                LoanAmount:loanAmount,
                LoanPeriodInMonths:loanPeriodInMonths,
                ClientId:clientId);
            
            var result = await mediator.Send(query, cancellationToken);
            return ResultOf(result);
        }
    }
}
