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
    public class AddABRoundToNewGameMutation : BaseMutation
    {
        public AddABRoundToNewGameMutation(HttpContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<ABRoundAddedToNewGame> AddABRoundToNewGame(AddABRoundToNewGameInput input)
        {
            PlayableGame playableGame = await _mediator.Send(new AddABRoundToNewGameCommand(
                UserId,
                input.Id,
                input.Name,
                input.Questions
            ));

            return new ABRoundAddedToNewGame(playableGame.Id.ToString());
        }
    }

    public record AddABRoundToNewGameInput(string Id, string Name, ABQuestionDto[] Questions);

    public record ABRoundAddedToNewGame(string Id);
}
