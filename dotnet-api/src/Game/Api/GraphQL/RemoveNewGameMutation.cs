using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using Pubquizish.Game.Domain;
using Pubquizish.Game.Domain.Command;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Api.GraphQL
{

    [ExtendObjectType("Mutation")]
    [Authorize]
    public class RemoveNewGameMutation : BaseMutation
    {
        public RemoveNewGameMutation(HttpContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<RemovedNewGame> RemoveNewGame(RemoveNewGameInput input)
        {
            NewGame newGame = await _mediator.Send(new RemoveNewGameCommand(
                UserId,
                input.Id
            ));

            return new RemovedNewGame(newGame.Id.ToString());
        }
    }

    public record RemoveNewGameInput(string Id);

    public record RemovedNewGame(string Id);
}
