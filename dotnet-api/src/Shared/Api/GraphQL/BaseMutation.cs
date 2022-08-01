using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Pubquizish.Shared.Domain
{
    public abstract class BaseMutation
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IMediator _mediator;

        protected BaseMutation(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        protected string UserId
        {
            get
            {
                string? userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    return userId;
                }

                throw new UnauthorizedAccessException();
            }
        }
    }
}
