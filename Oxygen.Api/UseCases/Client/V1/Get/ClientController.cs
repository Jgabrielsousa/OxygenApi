using Microsoft.AspNetCore.Mvc;
using Oxygen.Api.Presenters;
using Oxygen.Application.UseCases.Client.V1.Get;
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
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid id) {

            var command = new GetCommand
            {
                Id= id,
            };
            var response = await _mediator.Send(command);
            return await DefaultPresenter.Cast(response, HttpStatusCode.OK);
        }
    }
}