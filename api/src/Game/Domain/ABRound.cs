using System;
using System.Collections.Generic;
using System.Linq;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Domain
{
    public class ABRound : BaseEntity, IRound
    {
        private readonly List<ABQuestion> _questions = default!;
        private readonly string _name = default!;

        public ABRound(string name, List<ABQuestion> questions)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("A round has to have a name.");
            }
            _name = name;
            if (!questions.Any())
            {
                throw new ArgumentException("AB round has to have questions.");
            }
            _questions = questions;
        }
    }
}
