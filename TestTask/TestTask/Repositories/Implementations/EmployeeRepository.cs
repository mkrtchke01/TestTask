using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Repositories.Contracts;
using TestTask.Requests;

namespace TestTask.Repositories.Implementations
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly TestTaskDbContext _context;

        public EmployeeRepository(TestTaskDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AddEmployeeRequest entity)
        {
            var positions = new List<Position>();
            foreach (var positionId in entity.PositionIds)
            {
                var item = _context.Positions.SingleOrDefault(p => p.PositionId == positionId);
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                positions.Add(item);
            }
            var employee = new Employee
            {
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                Positions = positions
            };
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees
                .AsNoTracking()
                .Include(p => p.Positions)
                .SingleOrDefaultAsync(e => e.EmployeeId== id);
            return employee;
        }

        public async Task UpdateAsync(UpdateEmployeeRequest entity, int id)
        {
            var employee = await _context.Employees
                .Include(p=>p.Positions)
                .SingleOrDefaultAsync(e=>e.EmployeeId== id);
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            employee.FullName = entity.FullName;
            employee.BirthDate = entity.BirthDate;
            var positions = new List<Position>();
            foreach (var positionId in entity.PositionIds)
            {
                var item = _context.Positions.SingleOrDefault(p => p.PositionId == positionId);
                if(item == null)
                {
                    throw new ArgumentNullException();
                }
                positions.Add(item);
            }
            employee.Positions = positions;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
