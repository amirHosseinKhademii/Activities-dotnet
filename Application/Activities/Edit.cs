using AutoMapper;
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
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var prev = await _context.Activities.FindAsync(request.Activity.Id);

                if (prev != null)
                {
                    _mapper.Map(request.Activity, prev);
                }


                await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}