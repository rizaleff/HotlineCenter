using API.Dtos.Accounts;
using API.DTOs;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories;
public class AccountRepository : GeneralRepository<AccountDto, Guid>, IAccountRepository
{

    public AccountRepository(string request = "Account/") : base(request)
    {
    }

    public async Task<ResponseOKHandler<TokenDto>> Login(LoginDto login)
    {
        string jsonEntity = JsonConvert.SerializeObject(login);
        StringContent content = new StringContent(jsonEntity, Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync($"{request}login", content))
        {
            response.EnsureSuccessStatusCode();
            string apiResponse = await response.Content.ReadAsStringAsync();

            var entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<TokenDto>>(apiResponse);
            return entityVM;
        }
    }

    public async Task<ResponseOKHandler<RegisterAccountDto>> Register(RegisterAccountDto register)
    {
        string jsonEntity = JsonConvert.SerializeObject(register);
        StringContent content = new StringContent(jsonEntity, Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync($"{request}register", content))
        {
            response.EnsureSuccessStatusCode();
            string apiResponse = await response.Content.ReadAsStringAsync();

            var entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<RegisterAccountDto>>(apiResponse);
            return entityVM;
        }
    }

}