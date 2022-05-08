namespace ProjectVFront.Crosscutting.Dtos;
public record AddTransactionRequestDto(string Description, double Value, DateTime Date, int CategoryId);
