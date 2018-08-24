using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoodCode.API.Features.Users
{
    [ApiController]
    [Route("api/users")]
    public class UsersController
    {
        protected readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<GetUsersQuery.Response>> Get() {
            return await _mediator.Send(new GetUsersQuery.Request());
        }
    }
}
