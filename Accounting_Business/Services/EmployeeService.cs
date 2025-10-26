using Accounting_Business.Persistence.Entities;
using Accounting_Business.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        Task<Employee> GetByCode(string code);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task<List<Employee>> GetEmployeesByFilters(EmployeeFilterModel employeeFilter);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public async Task<Employee> GetByCode(string code)
        {
            return await _context.Employees
                .Include(e => e.MaritalStatus)
                .Include(e => e.Gender)
                .Include(e => e.Classification)
                .SingleOrDefaultAsync(e => e.EmployeeCode == code);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public async Task<List<Employee>> GetEmployeesByFilters(EmployeeFilterModel employeeFilter)
        {
            var query = _context.Employees
                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeCode))
                query = query.Where(a => a.EmployeeCode == employeeFilter.EmployeeCode);

            if (!string.IsNullOrWhiteSpace(employeeFilter.Name))
                query = query.Where(a => a.Name == employeeFilter.Name);

            if (!string.IsNullOrWhiteSpace(employeeFilter.IdenificationNumber))
                query = query.Where(a => a.IdentificationNumber == employeeFilter.IdenificationNumber);

            if (!string.IsNullOrEmpty(employeeFilter.Address))
                query = query.Where(a => a.Address == employeeFilter.Address);

            if (!string.IsNullOrEmpty(employeeFilter.FirstPhoneNumber))
                query = query.Where(a => a.FirstPhoneNumber == employeeFilter.FirstPhoneNumber);

            if (employeeFilter.BirthDate.HasValue)
                query = query.Where(a => a.BirthDate == DateOnly.FromDateTime(employeeFilter.BirthDate.Value));

            if (employeeFilter.HiringDate.HasValue)
                query = query.Where(a => a.HiringDate == DateOnly.FromDateTime(employeeFilter.HiringDate.Value));

            return await query
                .ToListAsync();
        }
    }
}
