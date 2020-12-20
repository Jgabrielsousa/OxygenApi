using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Oxygen.Api.UseCases.Client.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public partial class ClientController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>

        private readonly IMediator _mediator;
        public ClientController(IMediator mediator) => _mediator = mediator;

    }
}