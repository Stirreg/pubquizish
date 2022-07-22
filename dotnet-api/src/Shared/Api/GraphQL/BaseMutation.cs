using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Pubquizish.Shared.Domain
{
    public abstract class BaseMutation
    {
        protected readonly HttpContext _context;
        protected readonly IMediator _mediator;

        protected BaseMutation(HttpContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        protected string UserId
        {
            get
            {
                string userId = _context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    return userId;
                }

                throw new UnauthorizedAccessException();
            }
        }
    }
}
