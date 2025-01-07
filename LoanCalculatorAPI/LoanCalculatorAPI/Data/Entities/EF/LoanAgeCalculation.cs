using System;
using System.Collections.Generic;

namespace LoanCalculatorAPI.Data.Entities.EF;

public partial class LoanAgeCalculation
{
    public Guid Id { get; set; }

    public int MinAge { get; set; }

    public int MaxAge { get; set; }

    public decimal LoanMinAmount { get; set; }

    public decimal? LoanMaxAmount { get; set; }

    public decimal InterestRate { get; set; }

    public bool IsWithPrimeInterest { get; set; }

    public int? LoanPeriodExtraMonthInterestId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual LoanPeriodExtraMonthInterest? LoanPeriodExtraMonthInterest { get; set; }
}