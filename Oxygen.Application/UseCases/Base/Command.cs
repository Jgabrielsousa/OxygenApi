using Flunt.Notifications;
using MediatR;
using Oxygen.Application.Results;

namespace Oxygen.Application.UseCases.Base
{
    public abstract class Command<T> : Notifiable, IRequest<Result>
        where T : Command<T>
       , new()
    {
    }
}
