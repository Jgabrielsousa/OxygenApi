using Oxygen.Application.UseCases.Base;

namespace Oxygen.Application.UseCases.Client.V1.Create
{
    public class CreateCommand : Command<CreateCommand>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
