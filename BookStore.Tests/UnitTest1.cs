using Xunit;
using BookStore.Domain.Policies;
using BookStore.Domain.Entities;
using BookStore.Domain.Enums;

public class PromotionPolicyTests
{
    private readonly DateTime fixedNow = new DateTime(2026, 4, 18);

    [Fact] // Happy Path
    public void Should_GetPromotion_When_AllConditionsMatch()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales }
        };

        var storeOpenDate = fixedNow.AddMonths(-3);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.True(result);
    }

    [Fact] // Book < 5
    public void Should_NotGetPromotion_When_NotEnoughBooks()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables }
        };

        var storeOpenDate = fixedNow.AddMonths(-3);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.False(result);
    }

    [Fact] // category = Other ทั้งหมด
    public void Should_NotGetPromotion_When_AllBooksAreOtherCategory()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Other },
            new Book { Category = BookCategory.Other },
            new Book { Category = BookCategory.Other },
            new Book { Category = BookCategory.Other },
            new Book { Category = BookCategory.Other }
        };

        var storeOpenDate = fixedNow.AddMonths(-3);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.False(result);
    }

    [Fact] // เกิน 6 เดือน
    public void Should_NotGetPromotion_When_StoreOver6Months()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales }
        };

        var storeOpenDate = fixedNow.AddMonths(-7);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.False(result);
    }

    [Fact] // exactly 6 months
    public void Should_GetPromotion_When_Exactly6Months()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales }
        };

        var storeOpenDate = fixedNow.AddMonths(-6);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.True(result);
    }

    [Fact] // 5 valid books + other
    public void Should_GetPromotion_When_Exactly5ValidBooks_MixedWithOther()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Other }
        };

        var storeOpenDate = fixedNow.AddMonths(-2);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.True(result);
    }

    [Fact] // ไม่ subscribe
    public void Should_NotGetPromotion_When_NotSubscribed()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = false };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales }
        };

        var storeOpenDate = fixedNow.AddMonths(-2);

        var result = policy.IsEligible(user, books, fixedNow, storeOpenDate);

        Assert.False(result);
    }
}