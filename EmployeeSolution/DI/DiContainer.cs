using Autofac;
using EmployeeSolution.Repositories;
using EmployeeSolution.Repositories.Interfaces;
using EmployeeSolution.Services;
using EmployeeSolution.Services.Interfaces;

namespace EmployeeSolution.DI
{
    public static class DiContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>();
            builder.RegisterType<EmployeesService>().As<IEmployeesService>();
        }
    }
}