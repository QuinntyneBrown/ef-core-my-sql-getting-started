using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using GoodCode.Core.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GoodCode.API.Features.Users
{
    public class GetUsersQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<UserDto> Users { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Users = await _context.Users.Select(x => UserDto.FromUser(x)).ToListAsync()
                };
        }
    }
}
