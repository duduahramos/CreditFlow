using CreditFlow.Core.Domain.Entities;
using CreditFlow.API.DTOs;
using CreditFlow.Core.Common.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CreditFlow.API.Utils.Mappers;

public static class UserMapper
{
    public static UserDTO ToDto(this User request)
    {
        return new UserDTO()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Username = request.Username,
            CreatedAt = request.CreatedAt
        };
    }

    public static User ToEntity(this UserDTO? request)
    {
        var userSalt = AuthHelper.GenerateSalt();
        
        return new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Username = request.Username,
            PasswordSalt = userSalt,
            PasswordHash = AuthHelper.HashPassword(request.Password, userSalt)
        };
    }
}