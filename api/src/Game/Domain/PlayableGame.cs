using System;
using System.Collections.Generic;
using System.Linq;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Domain
{
    public class PlayableGame : BaseEntity, IAggregateRoot
    {
        private readonly string _name = default!;
        private readonly string _code = default!;
        private readonly Guid _creatorId;
        private readonly DateTime _createdOn;
        private readonly List<IRound> _rounds = default!;

        public PlayableGame() { }

        public PlayableGame(Guid id, string name, string code, Guid creatorId, DateTime createdOn, List<IRound> rounds)
        {
            Id = id;
            _code = code;
            _name = name;

            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentException("Playable game has to have a name.");
            }

            _creatorId = creatorId;
            _createdOn = createdOn;
            _rounds = rounds;

            if (!_rounds.Any())
            {
                throw new ArgumentException("Playable game has to have rounds.");
            }
        }

        public bool isCreator(Guid userId)
        {
            return userId == _creatorId;
        }
    }
}
