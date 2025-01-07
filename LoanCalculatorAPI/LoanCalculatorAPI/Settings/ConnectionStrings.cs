using System.ComponentModel.DataAnnotations;

namespace LoanCalculatorAPI.Settings;

public class ConnectionStrings
{
    [Required] public string DefaultConnection { get; set; }
}