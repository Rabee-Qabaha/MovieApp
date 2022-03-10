using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Models;
using MovieApp.EF.Data;
using System.Linq.Expressions;


namespace MovieApp.EF.Repositories
{
    public class ActorRepository : IActorRepository
    {
        protected AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAll(string[] includes = null)
        {
            IQueryable<Actor> query = _context.Set<Actor>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }
        public async Task<Actor> GetById(int id)
        {
            return await _context.Set<Actor>().FindAsync(id);
        }
        public async Task<IEnumerable<Actor>> Find(Expression<Func<Actor, bool>> match, string[] includes = null)
        {
            IQueryable<Actor> query = _context.Set<Actor>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(match).ToListAsync();
        }
        public async Task<Actor> Add(Actor entity)
        {
            var result = await _context.Set<Actor>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Actor> Update(Actor entity)
        {
            var result = _context.Set<Actor>().Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<Actor> Delete(Actor entity)
        {
            var result = _context.Set<Actor>().Remove(entity);
          await  _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
