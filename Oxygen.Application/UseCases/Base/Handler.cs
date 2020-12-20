using MediatR;
using Oxygen.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.UseCases.Base
{
    public abstract class Handler<T> : IRequestHandler<T, Result>
        where T : Command<T>, new()
    {
        public Result Result { get; set; }

        public string HandlerName => nameof(T);

        protected Handler()
        {
            Result = new Result();
        }

        public abstract Task<Result> Handle(T request, CancellationToken cancellationToken);

    }
}
