using BookStore.Domain.Entities;
using BookStore.Domain.Enums;

namespace BookStore.Domain.Policies;

public class PromotionPolicy
{
    public bool IsEligible(User user, List<Book> books, DateTime now, DateTime storeOpenDate)
    {
        if (!user.Subscription)
            return false;

        if (now.Date > storeOpenDate.AddMonths(6).Date)
            return false;

        int count = books.Count(b =>
            b.Category == BookCategory.Tales ||
            b.Category == BookCategory.Fables
        );

        return count >= 5;
    }
}