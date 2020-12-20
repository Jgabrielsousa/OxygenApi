using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Application.UseCases.Client.V1.Create
{
    public class CreateResult
    {
        public Guid Id { get; set; }
        public CreateResult(Guid id) => Id = id;
    }
}
