using System;
using Pubquizish.Game.Domain;
using Pubquizish.Shared.Domain;

namespace Pubquizish.Game.Infrastructure.EntityFramework
{
    public class NewGameRepository : IRepository<NewGame>
    {
        private readonly GameDbContext _gameDbContext;

        public NewGameRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public void Add(NewGame newGame)
        {
            _gameDbContext.Add(newGame);
            _gameDbContext.SaveChanges();
        }

        public void Update(NewGame newGame)
        {
            _gameDbContext.Update(newGame);
            _gameDbContext.SaveChanges();
        }

        public NewGame Find(Guid Id)
        {
            return _gameDbContext.Find<NewGame>(Id);
        }

        public void Remove(NewGame newGame)
        {
            _gameDbContext.Remove(newGame);
            _gameDbContext.SaveChanges();
        }
    }
}
