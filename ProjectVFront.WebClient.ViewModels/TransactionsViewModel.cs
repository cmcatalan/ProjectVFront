using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.WebClient.ViewModels;
public class TransactionsViewModel
{
    public IEnumerable<TransactionCategoryDto> Transactions { get; set; } = new List<TransactionCategoryDto>();
    public IFormatProvider FormatProvider { get; set; }

    public TransactionsViewModel(IFormatProvider formatProvider)
    {
        Transactions = new List<TransactionCategoryDto>();
        FormatProvider = formatProvider;
    }
}
