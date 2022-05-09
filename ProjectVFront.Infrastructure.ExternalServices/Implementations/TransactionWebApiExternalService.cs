using Flurl.Http;
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
    public async Task<IEnumerable<TransactionCategoryDto>> GetAllTransactionsWithCategoryInfo(GetTransactionsRequestDto dto)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsGetAction)
            .GetJsonAsync<IEnumerable<TransactionCategoryDto>>();
    }

    public async Task<TransactionsSummaryDto> GetSummary(GetTransactionsSummaryRequestDto dto)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsGetSummaryAction)
           .GetJsonAsync<TransactionsSummaryDto>();
    }

    public async Task<IEnumerable<TransactionsSumGroupByCategoryDto>> GetTransactionsSumGroupByCategory(GetTransactionsRequestDto dto)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsGetTransactionsSumGroupByCategoryAction)
            .GetJsonAsync<IEnumerable<TransactionsSumGroupByCategoryDto>>();
    }
    public async Task<TransactionDto> Add(AddTransactionRequestDto dto)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsAddAction)
            .PostJsonAsync(dto)
            .ReceiveJson<TransactionDto>();
    }

    public async Task<TransactionDto> Edit(EditTransactionRequestDto dto)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsEditAction)
            .PutJsonAsync(dto)
            .ReceiveJson<TransactionDto>();
    }

    public async Task<TransactionDto> Delete(int transactionId)
    {
        return await _flurlClient.Request(_transactionsWebApiOptions.TransactionsRoute, _transactionsWebApiOptions.TransactionsDeleteAction, transactionId)
            .DeleteAsync()
            .ReceiveJson<TransactionDto>();
    }
}
