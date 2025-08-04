using CreditFlow.Core.Domain.Entities;
using CreditFlow.API.Models;

namespace CreditFlow.API.Utils.Mappers;

public static class CreditRequestMapper
{
    public static CreditRequestDTO ToDto(this CreditRequest request)
    {
        return new CreditRequestDTO()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Cpf = request.Cpf,
            Age = request.Age,
            MonthlyIncome = request.MonthlyIncome,
            RequestAmount = request.RequestAmount,
            CreditScore = request.CreditScore,
            HasDebtHistory = request.HasDebtHistory,
            CreatedAt = request.CreatedAt,
            UpdatedAt = request.UpdatedAt,
            EndedAt = request.EndedAt,
            RequestStatus = request.RequestStatus
        };
    }

    public static CreditRequest ToEntity(this CreditRequestDTO? request)
    {
        return new CreditRequest()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Cpf = request.Cpf,
            Age = request.Age,
            MonthlyIncome = request.MonthlyIncome,
            RequestAmount = request.RequestAmount,
            CreditScore = request.CreditScore,
            HasDebtHistory = request.HasDebtHistory,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            EndedAt = null,
            RequestStatus = request.RequestStatus
        };
    }
}