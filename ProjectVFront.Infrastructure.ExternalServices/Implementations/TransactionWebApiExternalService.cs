using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.Crosscutting.Utils;

namespace ProjectVFront.Infrastructure.ExternalServices;
public class TransactionWebApiExternalService : WebApiExternalServiceBase, ITransactionWebApiExternalService
{
    private readonly TransactionsWebApiOptions _transactionsWebApiOptions;
    public TransactionWebApiExternalService(
        IFlurlClientFactory flurlClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IOptions<BaseWebApiOptions> baseWebApiOptions,
        IOptions<TransactionsWebApiOptions> transactionsWebApiOptions) : base(flurlClientFactory, httpContextAccessor, baseWebApiOptions)
    {
        _transactionsWebApiOptions = transactionsWebApiOptions.Value;
    }
    public async Task<TransactionDto> Add(string userId, AddTransactionRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionDto> Delete(string userId, int transactionId)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionDto> Edit(string userId, EditTransactionRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TransactionCategoryDto>> GetAllTransactionsWithCategoryInfo(string userId, GetTransactionsRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionsSummaryDto> GetSummary(string userId, GetTransactionsSummaryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TransactionsSumGroupByCategoryDto>> GetTransactionsSumGroupByCategory(string userId, GetTransactionsRequestDto dto)
    {
        throw new NotImplementedException();
    }
}
