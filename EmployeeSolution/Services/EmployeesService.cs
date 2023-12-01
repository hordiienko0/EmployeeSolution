using EmployeeSolution.Models;
using EmployeeSolution.Repositories.Interfaces;
using EmployeeSolution.Services.Interfaces;

namespace EmployeeSolution.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeesRepository.GetEmployeeById(id);
        }

        public void EnableEmployee(int id, bool enable)
        {
            _employeesRepository.EnableEmployee(id, enable);
        }
    }
}
