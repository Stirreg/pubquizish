using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Pubquizish.Game.Domain;
using Pubquizish.Game.Domain.Command;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Application
{
    public class CreateNewGameHandler : IRequestHandler<CreateNewGameCommand, NewGame>
    {
        private readonly IRepository<NewGame> _newGameRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateNewGameHandler(IRepository<NewGame> newGameRepository, IHttpContextAccessor httpContextAccessor)
        {
            _newGameRepository = newGameRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<NewGame> Handle(CreateNewGameCommand command, CancellationToken cancellationToken)
        {
            string? userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            Guid creatorId = Guid.Parse(userId);

            var newGame = new NewGame(command.Name, creatorId);

            _newGameRepository.Add(newGame);

            return newGame;
        }
    }
}
