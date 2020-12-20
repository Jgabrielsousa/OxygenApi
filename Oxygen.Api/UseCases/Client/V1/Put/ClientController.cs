using Microsoft.AspNetCore.Mvc;
using Oxygen.Api.Model;
using Oxygen.Api.Presenters;
using Oxygen.Application.UseCases.Client.V1.Alter;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Oxygen.Api.UseCases.Client.V1
{
    public partial  class ClientController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
         [HttpPut("{id}")]
        [ProducesResponseType(typeof(AlterResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ClientModel request)
        {
            var command = new AlterCommand
            {
                Id = id,
                Nome = request.Nome,
                Idade = request.Idade
            };
            var response = await _mediator.Send(command);
            return await DefaultPresenter.Cast(response, HttpStatusCode.OK);
        }
    }
}