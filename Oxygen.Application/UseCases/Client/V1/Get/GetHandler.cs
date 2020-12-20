using Flunt.Notifications;
using Oxygen.Application.Results;
using Oxygen.Application.Results.Dtos;
using Oxygen.Application.UseCases.Base;
using Oxygen.Domain.Enum;
using Oxygen.Domain.Interfaces.IRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.UseCases.Client.V1.Get
{
    public class GetHandler : Handler<GetCommand>
    {
        private readonly IClientRepository _repository;
        public GetHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public override async  Task<Result> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _repository.Find(request.Id);

                if (item ==null) 
                    Result.AddNotification(new Notification("Get Error", "Was not possible find ther user"), ErrorCode.NotFound);
                else 
                    Result.Data = new GetResult(new ClientDto(item.Id, item.Nome, item.Idade));
            }
            catch (Exception error)
            {
                Result.AddNotification(new Notification("Get Error", "Was not possible to create the user"), ErrorCode.InternalError);
            }
            return Result;
        }
    }
}
