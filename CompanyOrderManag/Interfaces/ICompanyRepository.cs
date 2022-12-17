using CompanyOrderManag.Models;

namespace CompanyOrderManag.Interfaces
{
    public interface ICompanyRepository
    {
        ICollection<Company> GetCompanies();
        Company GetCompany(int id);
        bool CompanyExist(int id);
        bool CreateCompany(Company company);
        bool UpdateCompany(Company company);
        bool Save();
    }
}


