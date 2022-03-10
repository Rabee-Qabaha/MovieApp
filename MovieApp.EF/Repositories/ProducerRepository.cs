using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Models;
using MovieApp.EF.Data;
using System.Linq.Expressions;

namespace MovieApp.EF.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        protected AppDbContext _context;
        public ProducerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producer>> GetAll(string[] includes = null)
        {
            IQueryable<Producer> query = _context.Set<Producer>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }
        public async Task<Producer> GetById(int id)
        {
            return await _context.Set<Producer>().FindAsync(id);
        }
        public async Task<IEnumerable<Producer>> Find(Expression<Func<Producer, bool>> match, string[] includes = null)
        {
            IQueryable<Producer> query = _context.Set<Producer>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(match).ToListAsync();
        }
        public async Task<Producer> Add(Producer entity)
        {
            var result = await _context.Set<Producer>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Producer> Update(Producer entity)
        {
            var result = _context.Set<Producer>().Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<Producer> Delete(Producer entity)
        {
            var result = _context.Set<Producer>().Remove(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
