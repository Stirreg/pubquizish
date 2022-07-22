using System;
using Pubquizish.Game.Domain;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Infrastructure.EntityFramework
{
    public class PlayableGameRepository : IRepository<PlayableGame>
    {
        private readonly GameDbContext _gameDbContext;

        public PlayableGameRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public void Add(PlayableGame playableGame)
        {
            _gameDbContext.Add(playableGame);
            _gameDbContext.SaveChanges();
        }

        public void Update(PlayableGame playableGame)
        {
            _gameDbContext.Update(playableGame);
            _gameDbContext.SaveChanges();
        }

        public PlayableGame Find(Guid Id)
        {
            return _gameDbContext.Find<PlayableGame>(Id);
        }

        public void Remove(PlayableGame playableGame)
        {
            _gameDbContext.Remove(playableGame);
            _gameDbContext.SaveChanges();
        }
    }
}
