using TestTask.Models;
using TestTask.Requests;

namespace TestTask.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(AddEmployeeRequest entity);
        Task DeleteAsync(Employee entity);
        Task UpdateAsync(UpdateEmployeeRequest entity, int id);
    }
}
