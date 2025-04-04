using Domain;
using Mapster;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class EditActivity
{
	public class Command : IRequest
	{
		public required Activity Activity { get; set; }
	}

    public class Handler(AppDBContext context) : IRequestHandler<Command>
    {
		public async Task Handle(Command request, CancellationToken cancellationToken)
		{
			var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken)
				?? throw new Exception("Cannot find activity");

			request.Activity.Adapt(activity);

			await context.SaveChangesAsync(cancellationToken);
        }
    }
}
