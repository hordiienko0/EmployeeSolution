using EmployeeSolution.Models;
using EmployeeSolution.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeSolution.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly string _connectionString;

        public EmployeesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void EnableEmployee(int id, bool enable)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("UPDATE Employee SET Enable = @Enable WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Enable", enable);

            command.ExecuteNonQuery();
        }

        public Employee GetEmployeeById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("SELECT * FROM Employee WHERE Id = @Id; SELECT * FROM Employee WHERE ManagerId = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            var employee = reader.Read() ? MapEmployee(reader) : null;

            if (employee != null)
            {
                reader.NextResult();
                employee.Employees = MapSubordinates(reader);
            }

            return employee;
        }

        private Employee MapEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                ManagerId = reader["ManagerId"] as int?,
                Enable = Convert.ToBoolean(reader["Enable"]),
                Employees = new List<Employee>()
            };
        }

        private List<Employee> MapSubordinates(SqlDataReader reader)
        {
            var subordinates = new List<Employee>();

            while (reader.Read())
            {
                subordinates.Add(new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    ManagerId = reader["ManagerId"] as int?,
                    Enable = Convert.ToBoolean(reader["Enable"]),
                    Employees = new List<Employee>()
                });
            }

            return subordinates;
        }
    }
}