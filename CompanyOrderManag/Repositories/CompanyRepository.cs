using CompanyOrderManag.Data;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;

namespace CompanyOrderManag.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CompanyExist(int id)
        {
            return _context.Companies.Any(c => c.Id == id); 
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(c => c.Id).ToList();
        }

        public Company GetCompany(int id)
        {
            return _context.Companies.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool CreateCompany(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool UpdateCompany(Company company)
        {
            _context.Update(company);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        
    }
}
