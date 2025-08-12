using CreditFlow.API.DTOs;
using CreditFlow.Core.Domain.Entities;

namespace CreditFlow.API.Utils.Mappers;

public static class LoginMapper
{
    public static LoginDTO ToDTO(this Login login)
    {
        return new LoginDTO
        {
            Username = login.Username,
            Token = login.Token,
            RefreshToken = login.RefreshToken
        };
    }

    public static Login ToEntity(this LoginDTO loginDTO)
    {
        return new Login
        {
            Username = loginDTO.Username,
            Token = loginDTO.Token,
            RefreshToken = loginDTO.RefreshToken
        };
    }
}