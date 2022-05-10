namespace ProjectVFront.Crosscutting.Dtos;
public record TransactionsSumGroupByCategoryDto(
        int CategoryId,
        string CategoryType,
        string CategoryName,
        string CategoryPictureUrl,
        bool CategoryIsDefault,
        double TransactionsSum);