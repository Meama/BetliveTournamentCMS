namespace Application.CSV.Models;

public class TurnamentResultCsvModel
{
    public bool IsWinner { get; set; }

    public string FullName { get; set; }

    public decimal PrizeAmount { get; set; }

    public string PersonalNumber { get; set; }

    public decimal CurrentBalance { get; set; }
}