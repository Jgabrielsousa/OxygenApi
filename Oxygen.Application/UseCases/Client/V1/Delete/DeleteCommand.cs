using Oxygen.Application.UseCases.Base;
using System;

namespace Oxygen.Application.UseCases.Client.V1.Delete
{
    public class DeleteCommand : Command<DeleteCommand>
    {
        public Guid Id { get; set; }
    }
}
