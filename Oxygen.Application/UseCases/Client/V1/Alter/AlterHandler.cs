using Flunt.Notifications;
using Oxygen.Application.Results;
using Oxygen.Application.Results.Dtos;
using Oxygen.Application.UseCases.Base;
using Oxygen.Domain.Enum;
using Oxygen.Domain.Interfaces.IRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.UseCases.Client.V1.Alter
{
    public class AlterHandler : Handler<AlterCommand>
    {
        private readonly IClientRepository _repository;
        public AlterHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public override async  Task<Result> Handle(AlterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _repository.Find(request.Id);

                if (item == null)
                    Result.AddNotification(new Notification("Get Error", "Was not possible find the user"), ErrorCode.NotFound);
                else
                {
                    item.Nome = request.Nome;
                    item.Idade = request.Idade;
                    _repository.Update(item);
                    Result.Data = new AlterResult(new ClientDto(item.Id, item.Nome, item.Idade));
                }
            }
            catch (Exception error)
            {
                Result.AddNotification(new Notification("Create Error", "Was not possible to update the user"), ErrorCode.InternalError);
            }
            return Result;
        }
    }
}
