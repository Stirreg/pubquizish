using System;
using MediatR;

namespace Pubquizish.Game.Domain.Command
{
    public record RemoveNewGameCommand(string UserId, string NewGameId) : IRequest<NewGame>;
}
