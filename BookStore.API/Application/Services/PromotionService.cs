using BookStore.Domain.Policies;
using BookStore.Application.DTOs;

namespace BookStore.Application.Services;

public class PromotionService
{
    private readonly PromotionPolicy _policy;
    private readonly DateTime _storeOpenDate = new DateTime(2026, 1, 1);

    public PromotionService(PromotionPolicy policy)
    {
        _policy = policy;
    }

    public bool Check(CheckPromotionRequest request)
    {
        return _policy.IsEligible(
            request.User,
            request.Books,
            DateTime.Now,
            _storeOpenDate
        );
    }
}