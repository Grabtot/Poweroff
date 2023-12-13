using MediatR;
using Poweroff.Models;
using System.Diagnostics;

namespace Poweroff.Commands
{
    public class ExitCommandHandler : IRequestHandler<ExitCommand, PoweroffResult>
    {
        public Task<PoweroffResult> Handle(ExitCommand request, CancellationToken cancellationToken)
        {
            Process.Start("shutdown", "/l /f /t 00");

            return Task.FromResult(new PoweroffResult(true));
        }
    }

    public record ExitCommand : IRequest<PoweroffResult>;
}
