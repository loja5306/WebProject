using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var objFromDb = _db.Companies.FirstOrDefault(u => u.Id == company.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = company.Name;
                objFromDb.StreetAddress = company.StreetAddress;
                objFromDb.City = company.City;
                objFromDb.County = company.County;
                objFromDb.PostCode = company.PostCode;
                objFromDb.PhoneNumber = company.PhoneNumber;
            }
        }

    }
}
