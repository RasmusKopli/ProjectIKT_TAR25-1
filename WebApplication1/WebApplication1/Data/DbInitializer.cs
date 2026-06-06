using Projekt.Models;

namespace Projekt.Data
{
    public class DbInitializer
    {
        public static void Initialize(WorkplaceContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee{Name="Carl Johnson",Position="Marketing",Reputation="Decent",Wage=1483},
                new Employee{Name="James Bond",Position="Deliveries",Reputation="Very Good",Wage=2650},
                new Employee{Name="Frank Tenpenny",Position="Security Guard",Reputation="Mediocre",Wage=1350},
                new Employee{Name="Michael Jordan",Position="Customer Support",Reputation="Okay",Wage=2100},
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();
        }
    }
}
