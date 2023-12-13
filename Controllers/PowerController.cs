using MediatR;
using Poweroff.Commands;
using Poweroff.Models;

namespace Poweroff.Controllers
{
    public class PowerController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        public PoweroffResult Exit()
        {
            PoweroffResult result = _mediator
                .Send(new ExitCommand()).Result;

            return result;
        }
    }
}
