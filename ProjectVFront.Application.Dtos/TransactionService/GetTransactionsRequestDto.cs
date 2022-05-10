using ProjectVFront.Crosscutting.Utils.enums;

namespace ProjectVFront.Crosscutting.Dtos;
public record GetTransactionsRequestDto(DateTime? From, DateTime? To, CategoryType? CategoryType);
