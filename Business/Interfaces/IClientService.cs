using Business.Models;
using Domain.Models;

namespace Business.Interfaces;

public interface IClientService
{
    Task<ClientResult<IEnumerable<Client>>> GetClientsAsync();
    Task<ClientResult<Client>> GetClientByIdAsync(string id);
}