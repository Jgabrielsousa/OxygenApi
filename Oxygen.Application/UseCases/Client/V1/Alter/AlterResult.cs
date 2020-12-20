using Oxygen.Application.Results.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Application.UseCases.Client.V1.Alter
{
    public class AlterResult
    {
        public ClientDto ClientDto { get; set; }
        public AlterResult(ClientDto clientDto) => ClientDto = clientDto;
    }
}
