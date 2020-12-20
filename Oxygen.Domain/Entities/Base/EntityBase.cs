using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Domain.Entities.Base
{
    public abstract class EntityBase<T> where T : class
    {
        public Guid Id { get; set; }

    }
}
