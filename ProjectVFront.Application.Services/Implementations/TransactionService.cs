using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Infrastructure.ExternalServices;

namespace ProjectVFront.Application.Services;
public class TransactionService : ITransactionService
{
    private readonly ITransactionWebApiExternalService _transactionsExternalService;
    public TransactionService(ITransactionWebApiExternalService transactionsExternalService)
    {
        _transactionsExternalService = transactionsExternalService;
    }

    public async Task<IEnumerable<TransactionCategoryDto>> GetAllTransactionsWithCategoryInfo(GetTransactionsRequestDto dto)
    {
        return await _transactionsExternalService.GetAllTransactionsWithCategoryInfo(dto);
    }

    public async Task<TransactionsSummaryDto> GetSummary(GetTransactionsSummaryRequestDto dto)
    {
        return await _transactionsExternalService.GetSummary(dto);
    }

    public async Task<IEnumerable<TransactionsSumGroupByCategoryDto>> GetTransactionsSumGroupByCategory(GetTransactionsRequestDto dto)
    {
        return await _transactionsExternalService.GetTransactionsSumGroupByCategory(dto);
    }
    public async Task<TransactionDto> Add(AddTransactionRequestDto dto)
    {
        return await _transactionsExternalService.Add(dto);
    }

    public async Task<TransactionDto> Delete(int transactionId)
    {
        return await _transactionsExternalService.Delete(transactionId);
    }

    public async Task<TransactionDto> Edit(EditTransactionRequestDto dto)
    {
        return await _transactionsExternalService.Edit(dto);
    }


}
