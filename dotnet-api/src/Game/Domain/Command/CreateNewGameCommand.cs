using System;
using MediatR;

namespace Pubquizish.Game.Domain.Command
{
    public record CreateNewGameCommand(string UserId, string Name) : IRequest<NewGame>;
}
