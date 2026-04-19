namespace BookStore.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public bool Subscription { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; } = false;
}