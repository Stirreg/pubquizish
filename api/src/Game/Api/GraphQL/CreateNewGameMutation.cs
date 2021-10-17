using System.Data;
using System.Threading.Tasks;
using Dapper;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Pubquizish.Game.Domain;
using Pubquizish.Game.Domain.Command;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Api.GraphQL
{
    [ExtendObjectType("Mutation")]
    [Authorize]
    public class CreateNewGameMutation : BaseMutation
    {
        public CreateNewGameMutation(HttpContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<GameReadModel> CreateNewGame([Service] IMediator mediator, [Service] IDbConnection dbConnection, CreateNewGameInput input)
        {
            NewGame newGame = await mediator.Send(new CreateNewGameCommand(UserId, input.Name));

            return dbConnection.QueryFirst<GameReadModel>("select Id, Name, Code, CreatorId, CreatedOn from NewGames where id = @Id", new { newGame.Id });
        }
    }

    public record CreateNewGameInput(string Name);
}
