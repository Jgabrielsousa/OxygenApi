using Oxygen.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Domain.Entities
{
    public class Client : EntityBase<Client>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
