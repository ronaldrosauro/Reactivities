using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class DeleteActivity
{
	public class Command : IRequest
	{
		public required string Id { get; set; }
	}

    public class Handler(AppDBContext context) : IRequestHandler<Command>
    {
		public async Task Handle(Command request, CancellationToken cancellationToken)
		{
			var delete = await context.Activities.FindAsync([request.Id], cancellationToken)
				?? throw new Exception("Activity not found");

			context.Activities.Remove(delete);
			
			await context.SaveChangesAsync(cancellationToken);
        }
    }
}
