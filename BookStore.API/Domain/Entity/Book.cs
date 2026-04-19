using BookStore.Domain.Enums;

namespace BookStore.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; } = null!;
    public string Writer { get; set; } = null!;
    public double Price { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; } = false;

    // ⭐ ใช้ใน promotion
    public BookCategory Category { get; set; }
}