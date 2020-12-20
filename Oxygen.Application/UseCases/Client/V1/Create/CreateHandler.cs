using Flunt.Notifications;
using Oxygen.Application.Results;
using Oxygen.Application.UseCases.Base;
using Oxygen.Domain.Enum;
using Oxygen.Domain.Interfaces.IRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.UseCases.Client.V1.Create
{
    public class CreateHandler : Handler<CreateCommand>
    {
        private readonly IClientRepository _repository;
        public CreateHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public override async  Task<Result> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
               var item  = _repository.Add(new Domain.Entities.Client()
                {
                    Idade = request.Idade,
                    Nome = request.Nome
                });
                Result.Data = new CreateResult(item.Id);
            }
            catch (Exception error)
            {
                Result.AddNotification(new Notification("Create Error", "Was not possible to create the user"), ErrorCode.InternalError);
            }
            return Result;
        }
    }
}
