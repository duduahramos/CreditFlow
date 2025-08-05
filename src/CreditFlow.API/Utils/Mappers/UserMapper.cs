using CreditFlow.Core.Domain.Entities;
using CreditFlow.API.DTOs;

namespace CreditFlow.API.Utils.Mappers;

public static class CreditRequestMapper
{
    public static CreditRequestDTO ToDto(this CreditRequest request)
    {
        return new CreditRequestDTO()
        {
            Id = request.Id,
            UserId = request.UserId,
            ClientId = request.ClientId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Cpf = request.Cpf,
            BirthDate = request.BirthDate,
            MonthlyIncome = request.MonthlyIncome,
            RequestAmount = request.RequestAmount,
            CreditScore = request.CreditScore,
            HasDebtHistory = request.HasDebtHistory,
            CreatedAt = request.CreatedAt,
            UpdatedAt = request.UpdatedAt,
            EndedAt = request.EndedAt,
            RequestStatus = request.RequestStatus.ToString()
        };
    }

    public static CreditRequest ToEntity(this CreditRequestDTO? request)
    {
        return new CreditRequest()
        {
            UserId = request.UserId,
            ClientId = request.ClientId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Cpf = request.Cpf,
            BirthDate = request.BirthDate,
            MonthlyIncome = request.MonthlyIncome,
            RequestAmount = request.RequestAmount,
            CreditScore = request.CreditScore,
            HasDebtHistory = request.HasDebtHistory,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            EndedAt = null
        };
    }
}