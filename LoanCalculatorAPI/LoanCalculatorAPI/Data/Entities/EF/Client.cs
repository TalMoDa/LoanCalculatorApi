using System;
using System.Collections.Generic;

namespace LoanCalculatorAPI.Data.Entities.EF;

public partial class Client
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public DateTime? CreatedAt { get; set; }
}