using Entity.model;
using SE1811.DAO;

namespace SE1811.Repository
{
    public class EmployeeRepository
    {
        private readonly ProductContext _context;
        public EmployeeRepository(ProductContext Context)
        {
            _context = Context;
        }

        IEnumerable<Employee> GetEmployees(int companyId)
        {
            return _context.Employees
                          .Where(e => e.CompanyId == companyId)
                          .ToList();
        }
        List<Employee> GetEmployee(int companyId, int id)
        {
            return _context.Employees
                   .Where(e => e.CompanyId == companyId && e.Id == id)
                   .ToList();
        }
        void CreateEmployeeForCompany(int companyId, Employee employee)
        {
            employee.CompanyId = companyId;  // Gán companyId cho nhân viên
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
