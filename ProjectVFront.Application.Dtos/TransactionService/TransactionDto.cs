namespace ProjectVFront.Crosscutting.Dtos;
public record TransactionDto(
       int Id,
       string Description,
       double Value,
       DateTime Date,
       int CategoryId,
       string UserId);