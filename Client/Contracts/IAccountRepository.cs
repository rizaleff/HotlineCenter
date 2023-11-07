using API.Dtos.Accounts;
using API.DTOs;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IAccountRepository : IRepository<AccountDto, Guid>
{
    Task<ResponseOKHandler<TokenDto>> Login(LoginDto login);
    Task<ResponseOKHandler<RegisterAccountDto>> Register(RegisterAccountDto register);
}