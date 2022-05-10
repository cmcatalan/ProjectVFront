namespace ProjectVFront.Crosscutting.Utils;

public class TransactionsWebApiOptions
{
    public const string SectionName = nameof(TransactionsWebApiOptions);

    public string TransactionsRoute { get; set; }
    public string TransactionsGetAction { get; set; }
    public string TransactionsGetSummaryAction { get; set; }
    public string TransactionsGetTransactionsSumGroupByCategoryAction { get; set; }
    public string TransactionsAddAction { get; set; }
    public string TransactionsEditAction { get; set; }
    public string TransactionsDeleteAction { get; set; }
}
