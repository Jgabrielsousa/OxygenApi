using Oxygen.Application.UseCases.Base;
using System;

namespace Oxygen.Application.UseCases.Client.V1.Get
{
    public class GetCommand : Command<GetCommand>
    {
        public Guid Id { get; set; }
    }
}
