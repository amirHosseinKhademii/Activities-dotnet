using Domain;
using MediatR;
using Presistence;

namespace Application.Activities
{
    public class Details
    {
        // create a handler for a indivitual activity
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Activity> Handle(Query request, System.Threading.CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);
                if (activity == null)
                {
                    // throw new RestException(System.Net.HttpStatusCode.NotFound, new { activity = "Not found" });
                }
                return activity;
            }
        }
    }
}