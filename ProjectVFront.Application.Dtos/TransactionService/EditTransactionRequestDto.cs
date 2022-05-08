namespace ProjectVFront.Crosscutting.Dtos;
public record EditTransactionRequestDto(int Id, string Description, double Value, DateTime Date, int CategoryId);