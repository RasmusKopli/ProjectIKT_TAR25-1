using Projekt.Models;

namespace Projekt.Data
{
    public class DbInitializer
    {
        public static void Initialize(WorkplaceContext context)
        {

            if (!context.Employees.Any())
            {
                var employees = new Employee[]
            {
                new Employee{Name="Carl Johnson",Position="Marketing",Reputation="Decent",Wage=1483},
                new Employee{Name="James Bond",Position="Deliveries",Reputation="Very Good",Wage=2650},
                new Employee{Name="Frank Tenpenny",Position="Security Guard",Reputation="Mediocre",Wage=1350},
                new Employee{Name="Michael Jordan",Position="Customer Support",Reputation="Okay",Wage=2100},
                new Employee{Name="Bruce Wayne",Position="Manager",Reputation="Excellent",Wage=5000},
                new Employee{Name="Leon Kennedy",Position="Programmer",Reputation="Very good",Wage=3100}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();
            }

            if (!context.JobPositions.Any())
            {
                var jobposition = new JobPositions[]
            {
                new JobPositions{JobName="Marketing",JobId=112,Salary=1483,IsAvailable=false},
                new JobPositions{JobName="Deliveries",JobId=241,Salary=2650,IsAvailable=false},
                new JobPositions{JobName="Security Guard",JobId=332,Salary=1350,IsAvailable=false},
                new JobPositions{JobName="Customer Support",JobId=424,Salary=2100,IsAvailable=false},
                new JobPositions{JobName="Manager",JobId=542,Salary=5000,IsAvailable=false},
                new JobPositions{JobName="Programmer",JobId=675,Salary=3100,IsAvailable=false},
                new JobPositions{JobName="Janitor",JobId=789,Salary=1200,IsAvailable=true}
            };
            foreach (JobPositions j in jobposition)
            {
                context.JobPositions.Add(j);
            }
            context.SaveChanges();
            }
        }
    }
}
