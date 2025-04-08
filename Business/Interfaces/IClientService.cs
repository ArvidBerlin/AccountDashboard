using Domain.Models;
using Domain.Responses;

namespace Business.Interfaces;

public interface IClientService
{
    Task<ClientResult<IEnumerable<Client>>> GetClientsAsync();
    Task<ClientResult<Client>> GetClientByIdAsync(string id);
}