using Flunt.Notifications;
using Oxygen.Application.Results;
using Oxygen.Application.UseCases.Base;
using Oxygen.Domain.Enum;
using Oxygen.Domain.Interfaces.IRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.UseCases.Client.V1.Delete
{
    public class DeleteHandler : Handler<DeleteCommand>
    {
        private readonly IClientRepository _repository;
        public DeleteHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public override async  Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _repository.Find(request.Id);

                if (item == null)
                    Result.AddNotification(new Notification("Get Error", "Was not possible find create"), ErrorCode.NotFound);
                else
                {
                    _repository.Remove(item);
                    Result.Data = new DeleteResult(item.Id);
                }


                Result.Data = new DeleteResult(item.Id);
            }
            catch (Exception error)
            {
                Result.AddNotification(new Notification("Create Error", "Was not possible to delete the user"), ErrorCode.InternalError);
            }
            return Result;
        }
    }
}
