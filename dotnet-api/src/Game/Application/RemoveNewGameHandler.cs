using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pubquizish.Game.Domain;
using Pubquizish.Game.Domain.Command;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Application
{
    public class RemoveNewgameHandler : IRequestHandler<RemoveNewGameCommand, NewGame>
    {
        private readonly IRepository<NewGame> _newGameRepository;

        public RemoveNewgameHandler(IRepository<NewGame> newGameRepository)
        {
            _newGameRepository = newGameRepository;
        }

        public async Task<NewGame> Handle(RemoveNewGameCommand command, CancellationToken cancellationToken)
        {
            NewGame newGame = _newGameRepository.Find(Guid.Parse(command.NewGameId));

            newGame.Remove(Guid.Parse(command.UserId));

            _newGameRepository.Remove(newGame);

            return newGame;
        }
    }
}
