using Domain;
using MediatR;
using Presistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var prev = await _context.Activities.FindAsync(request.Activity.Id);

                if (prev != null)
                {
                    prev.Title = request.Activity.Title ?? prev.Title;
                }


                await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}