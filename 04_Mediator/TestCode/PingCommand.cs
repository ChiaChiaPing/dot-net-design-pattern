using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace TestCode
{
    public class PingCommand : IRequest<PongResponse>
    {
        public PingCommand()
        {
        }
    }

    public class PongResponse
    {
        public DateTime TimeStamp;
        public PongResponse(DateTime dt)
        {
            this.TimeStamp = dt;
        }
    }

    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request,CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow)).ConfigureAwait(false);
        }
    }

  
}
