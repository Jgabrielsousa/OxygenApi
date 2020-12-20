using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Application.Results.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public ClientDto(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }
    }
}
