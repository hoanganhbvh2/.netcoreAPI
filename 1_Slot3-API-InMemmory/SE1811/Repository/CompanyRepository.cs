using System.Linq;
using Entity.model;
using SE1811.DAO;

namespace SE1811.Repository
{
    public class CompanyRepository
    {
        private readonly ProductContext _context;
        public CompanyRepository(ProductContext Context)
        {
            _context = Context;
        }

        List<Company> GetAllCompanies()
        {
            return _context.Company.ToList();
        }
        List<Company> GetCompany(int companyId)
        {
            //return _context.Company.Find(companyId);
            return _context.Company.Where(c => c.Id == companyId).ToList();
        }
        void CreateCompany(Company company)
        {
            _context.Company.Add(company);
            _context.SaveChanges();
        }
        IEnumerable<Company> GetByIds(int id)
        {
            var query = _context.Company.Where(c => c.Id == id);
            return query.ToList(); // Thực thi truy vấn};
        }
        void DeleteCompany(Company company)
        {
            _context.Company.Remove(company);
        }
    }
}
