using System;
using System.Collections.Generic;

namespace LoanCalculatorAPI.Data.Entities.EF;

public partial class PrimeInterest
{
    public int Id { get; set; }

    public decimal InterestRate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public bool IsActive { get; set; }
}