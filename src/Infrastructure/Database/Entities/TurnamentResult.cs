namespace Infrastructure.Database.Entities;

public class TurnamentResult
{
    public int Id { get; set; }

    public bool IsWinner { get; set; }

    public string FullName { get; set; }

    public decimal PrizeAmount { get; set; }

    public string PersonalNumber { get; set; }

    public decimal CurrentBalance { get; set; }
}