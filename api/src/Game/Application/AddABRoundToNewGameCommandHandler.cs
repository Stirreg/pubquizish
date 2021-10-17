using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Pubquizish.Game.Domain;
using Pubquizish.Game.Domain.Command;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Application
{
    public class AddABRoundToNewGameCommandHandler : IRequestHandler<AddABRoundToNewGameCommand, PlayableGame>
    {
        private readonly IRepository<NewGame> _newGameRepository;
        private readonly IRepository<PlayableGame> _playableGameRepository;

        public AddABRoundToNewGameCommandHandler(IRepository<NewGame> newGameRepository, IRepository<PlayableGame> playableGameRepository)
        {
            _newGameRepository = newGameRepository;
            _playableGameRepository = playableGameRepository;
        }

        public async Task<PlayableGame> Handle(AddABRoundToNewGameCommand command, CancellationToken cancellationToken)
        {
            NewGame newGame = _newGameRepository.Find(Guid.Parse(command.NewGameId));

            List<ABQuestion> questions = command.Questions.Select(question => new ABQuestion(question.Question, question.AnswerA, question.AnswerB)).AsList();

            PlayableGame playableGame = newGame.AddRound(Guid.Parse(command.UserId), new ABRound(command.Name, questions));

            _playableGameRepository.Add(playableGame);
            _newGameRepository.Remove(newGame);

            return playableGame;
        }
    }
}
