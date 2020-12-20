using Microsoft.AspNetCore.Mvc;
using Oxygen.Api.Presenters;
using Oxygen.Application.UseCases.Client.V1.Delete;
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
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id) {

            var command = new DeleteCommand
            {
                Id = id,
            };
            var response = await _mediator.Send(command);
            return await DefaultPresenter.Cast(response, HttpStatusCode.OK);
        }
    }
}