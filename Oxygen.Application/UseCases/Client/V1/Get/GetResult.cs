using Oxygen.Application.Results.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Application.UseCases.Client.V1.Get
{
    public class GetResult
    {
        public ClientDto ClientDto { get; set; }
        public GetResult(ClientDto clientDto) => ClientDto = clientDto;
    }
}
