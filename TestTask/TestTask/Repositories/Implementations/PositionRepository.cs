using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Repositories.Contracts;
using TestTask.Requests;

namespace TestTask.Repositories.Implementations
{
    public class PositionRepository : IPositionRepository
    {
        private readonly TestTaskDbContext _context;

        public PositionRepository(TestTaskDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AddPositionRequest entity)
        {
            var position = new Position
            {
                Name = entity.Name,
                Grade = entity.Grade
            };
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Position entity)
        {
            var isRelationship = _context.Employees
                .SelectMany(p => p.Positions)
                .Any(p => p.PositionId == entity.PositionId);
            if(!isRelationship) 
            {
                _context.Positions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Position> GetByIdAsync(int id)
        {
            var position = await _context.Positions
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PositionId == id);
            return position;
        }

        public async Task UpdateAsync(UpdatePositionRequest entity, int id)
        {
            var position = await _context.Positions.SingleOrDefaultAsync(p=>p.PositionId== id);
            position.Name = entity.Name;
            position.Grade = entity.Grade;
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
        }
    }
}
