using EmployeeSolution.Models;

namespace EmployeeSolution.Services.Interfaces
{
    public interface IEmployeesService
    {
        Employee GetEmployeeById(int id);

        void EnableEmployee(int id, bool enable);
    }
}
