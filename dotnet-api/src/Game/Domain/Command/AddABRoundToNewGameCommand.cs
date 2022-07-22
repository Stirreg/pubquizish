using MediatR;

namespace Pubquizish.Game.Domain.Command
{
    public record AddABRoundToNewGameCommand(string UserId, string NewGameId, string Name, ABQuestionDto[] Questions) : IRequest<PlayableGame>;
}
