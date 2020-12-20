using Microsoft.AspNetCore.Mvc;
using Oxygen.Api.Model;
using Oxygen.Api.Presenters;
using Oxygen.Application.UseCases.Client.V1.Create;
using System.Net;
using System.Threading.Tasks;

namespace Oxygen.Api.UseCases.Client.V1
{
    public partial  class ClientController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] ClientModel request) {

            var command = new CreateCommand
            { 
                Nome = request.Nome,
                Idade = request.Idade
            };
            var response = await _mediator.Send(command);
            return await DefaultPresenter.Cast(response, HttpStatusCode.Created);
        }
    }
}