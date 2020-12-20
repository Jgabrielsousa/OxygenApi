using Oxygen.Application.UseCases.Base;
using System;

namespace Oxygen.Application.UseCases.Client.V1.Alter
{
    public class AlterCommand : Command<AlterCommand>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
