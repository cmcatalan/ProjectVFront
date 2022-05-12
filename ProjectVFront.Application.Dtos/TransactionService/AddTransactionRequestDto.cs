namespace ProjectVFront.Crosscutting.Dtos;
public class AddTransactionRequestDto
{
    public string Description { get; set; } = string.Empty;
    public double Value { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
}
