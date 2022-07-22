using System;
using System.Collections.Generic;
using Pubquizish.Shared.Domain;
using shortid;
using shortid.Configuration;

namespace Pubquizish.Game.Domain
{
    public class NewGame : BaseEntity, IAggregateRoot
    {
        private readonly string _code = default!;
        private readonly string _name = default!;
        private readonly Guid _creatorId;
        private readonly DateTime _createdOn;

        public NewGame() { }

        public NewGame(string Name, Guid creatorId)
        {
            Id = Guid.NewGuid();
            _code = ShortId.Generate(new GenerationOptions
            {
                UseNumbers = false,
                UseSpecialCharacters = false,
            });
            _name = Name;
            _creatorId = creatorId;
            _createdOn = DateTime.Now;

            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("New game has to have a name.");
            }
        }

        public void Remove(Guid userId)
        {
            if (userId != _creatorId)
            {
                throw new UnauthorizedAccessException();
            }
        }

        public PlayableGame AddRound(Guid userId, IRound round)
        {
            if (userId != _creatorId)
            {
                throw new UnauthorizedAccessException();
            }

            return new PlayableGame(
                Id,
                _name,
                _code,
                _creatorId,
                _createdOn,
                new List<IRound> { round }
            );
        }
    }
}
