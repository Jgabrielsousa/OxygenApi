using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Application.UseCases.Client.V1.Delete
{
    public class DeleteResult
    {
        public Guid Id { get; set; }
        public DeleteResult(Guid id) => Id = id;
    }
}
