using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.Infrastructure.ExternalServices;
public interface ITransactionWebApiExternalService
{
    Task<IEnumerable<TransactionCategoryDto>> GetAllTransactionsWithCategoryInfo(GetTransactionsRequestDto dto);
    Task<TransactionsSummaryDto> GetSummary(GetTransactionsSummaryRequestDto dto);
    Task<IEnumerable<TransactionsSumGroupByCategoryDto>> GetTransactionsSumGroupByCategory(GetTransactionsRequestDto dto);
    Task<TransactionDto> Add(AddTransactionRequestDto dto);
    Task<TransactionDto> Edit(EditTransactionRequestDto dto);
    Task<TransactionDto> Delete(int transactionId);
}
