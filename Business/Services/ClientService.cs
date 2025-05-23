﻿using Business.Interfaces;
using Data.Interfaces;
using Domain.Extensions;
using Domain.Models;
using Domain.Responses;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ClientResult<IEnumerable<Client>>> GetClientsAsync()
    {
        var repositoryResult = await _clientRepository.GetAllAsync
            (
                orderByDescending: false,
                sortBy: x => x.ClientName
            );

        var entities = repositoryResult.Result;
        var clients = entities?.Select(entity => entity.MapTo<Client>()) ?? [];

        return new ClientResult<IEnumerable<Client>> { Succeeded = true, StatusCode = 200, Result = clients };
    }

    public async Task<ClientResult<Client>> GetClientByIdAsync(string id)
    {
        var repositoryResult = await _clientRepository.GetAsync(x => x.Id == id);

        var entity = repositoryResult.Result;
        if (entity == null)
            return new ClientResult<Client> { Succeeded = false, StatusCode = 404, Error = $"Client with id '{id}' not found." };

        var client = entity.MapTo<Client>();
        return new ClientResult<Client> { Succeeded = true, StatusCode = 200, Result = client };
    }
}
