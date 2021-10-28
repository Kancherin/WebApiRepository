using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.Api.Models;
using WebApiRepository.Api.Paging;

namespace WebApiRepository.Api.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {

        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployee(int id)
        {
            return FindbyCondition(e => e.Id == id).FirstOrDefault();
        }

        public Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Employee>
                .GetPageList(FindAll().OrderBy(s => s.Id), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        
    }
}
