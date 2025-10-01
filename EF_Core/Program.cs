using Microsoft.Extensions.Configuration;

namespace EF_Core
{
    class Program
    {
        static void Main(string[] args)
        {

            // Display all employees
            //using(var context = new AppDbContext())
            //{
            //    foreach(var emp in context.Employee
            //    {
            //        Console.WriteLine(emp.ToString);
            //        Console.WriteLine("--------------------------------------------------");
            //    }
            //}

            // Display employee with id = 1
            //var id = 1;
            //using (var context = new AppDbContext())
            //{
            //    var emp = context.Employee.FirstOrDefault(e => e.id == id);
            //    Console.WriteLine(emp);
            //}

            // Insert a new employee
            //var newEmployee = new Employee
            //{
            //    name = "Ahmed",
            //    salary = 60000,
            //    age = 30
            //};
            //using (var context = new AppDbContext())
            //{
            //    context.Employee.Add(newEmployee);
            //    context.SaveChanges();
            //    Console.WriteLine("New employee inserted with id = " + newEmployee.id);
            //}

            // Update employee with id = 1
            //var updatedEmployee = new Employee
            //{
            //    id = 1,
            //    name = "Amr Nabih(updated)",
            //    salary = 70000,
            //    age = 35
            //};

            //using(var context = new AppDbContext())
            //{
            //   var emp = context.Employee.Single(x=> x.id == 1);
            //    emp.name = updatedEmployee.name;
            //    emp.salary = updatedEmployee.salary;
            //    emp.age = updatedEmployee.age;

            //    context.SaveChanges();
            //    Console.WriteLine("Employee with id = " + updatedEmployee.id + " updated");
            //    var emp2 = context.Employee.FirstOrDefault(e => e.id == 1);
            //     Console.WriteLine(emp2);
            //}

            // Delete employee with id = 2
            //using(var context = new AppDbContext())
            //{
            //    var emp = context.Employee.Single(x=> x.id == 2);
            //    context.Employee.Remove(emp);
            //    context.SaveChanges();
            //    Console.WriteLine("Employee with id = 2 deleted");
            //}
        }
    } 
}