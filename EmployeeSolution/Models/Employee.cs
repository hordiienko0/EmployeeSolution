namespace EmployeeSolution.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ManagerId { get; set; }

        public bool Enable { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
