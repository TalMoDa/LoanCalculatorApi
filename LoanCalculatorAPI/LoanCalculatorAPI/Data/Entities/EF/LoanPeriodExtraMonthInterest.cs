using System;
using System.Collections.Generic;

namespace LoanCalculatorAPI.Data.Entities.EF;

public partial class LoanPeriodExtraMonthInterest
{
    public int Id { get; set; }

    public int ExtraMonths { get; set; }

    public decimal ExtraMonthInterestRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<LoanAgeCalculation> LoanAgeCalculations { get; set; } = new List<LoanAgeCalculation>();
}