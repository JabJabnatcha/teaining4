using BookStore.Domain.Entities;

namespace BookStore.Application.DTOs;

public class CheckPromotionRequest
{
    public User User { get; set; } = null!;
    public List<Book> Books { get; set; } = new();
}