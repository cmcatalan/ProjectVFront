using ProjectVFront.Crosscutting.Dtos;

namespace ProjectVFront.WebClient.ViewModels;
public class SummaryViewModel
{
    public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public IEnumerable<TransactionsSumGroupByCategoryDto> TransactionsSumGroups { get; set; } = new List<TransactionsSumGroupByCategoryDto>();
    public AddTransactionRequestDto AddTransactionRequestDto { get; set; } = new AddTransactionRequestDto();
    public IFormatProvider? FormatProvider { get; set; }

    public SummaryViewModel()
    {
        AddTransactionRequestDto = new AddTransactionRequestDto();
        Categories = new List<CategoryDto>();
        TransactionsSumGroups = new List<TransactionsSumGroupByCategoryDto>();
    }
    public SummaryViewModel(IFormatProvider formatProvider)
    {
        AddTransactionRequestDto = new AddTransactionRequestDto();
        Categories = new List<CategoryDto>();
        TransactionsSumGroups = new List<TransactionsSumGroupByCategoryDto>();
        FormatProvider = formatProvider;
    }
}
