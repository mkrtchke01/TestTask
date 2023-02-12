using TestTask.Models;
using TestTask.Requests;

namespace TestTask.Repositories.Contracts
{
    public interface IPositionRepository
    {
        Task<Position> GetByIdAsync(int id);
        Task AddAsync(AddPositionRequest entity);
        Task DeleteAsync(Position entity);
        Task UpdateAsync(UpdatePositionRequest entity, int id);
    }
}
