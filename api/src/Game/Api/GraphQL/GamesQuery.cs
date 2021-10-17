using System.Data;
using System.Linq;
using Dapper;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;

namespace Pubquizish.Game.Api.GraphQL
{
    [ExtendObjectType("Query")]
    [Authorize]
    public class GamesQuery
    {
        public IQueryable<GameReadModel> GetGames([Service] IDbConnection dbConnection)
        {
            return dbConnection.Query<GameReadModel>("select Id, Name, Code, CreatorId, CreatedOn from NewGames").AsQueryable();
        }
    }
}
