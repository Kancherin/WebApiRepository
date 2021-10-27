using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.Api.Models;

namespace WebApiRepository.Api.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {

        }
    }
}
