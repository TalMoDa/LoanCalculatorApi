namespace LoanCalculatorAPI.Helpers.Calculate;

public static class CalculateInterestHelper
{
    public static decimal CalculateBaseInterest(decimal loanAmount, decimal interestRate)
    {
        return loanAmount * (interestRate / 100);
    }
    
}