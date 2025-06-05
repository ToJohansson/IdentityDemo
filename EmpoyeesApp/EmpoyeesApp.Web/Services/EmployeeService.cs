using EmpoyeesApp.Web.Models;

namespace EmpoyeesApp.Web.Services;

public class EmployeeService
{
    List<Employee> employees = [
        new Employee{ Id = 1545, Name = "Tobias", Email = "tobbe@gmail.com"},
        new Employee{ Id = 23, Name = "Klara", Email = "klara@gmail.com"},
        new Employee{ Id = 234, Name = "Barbro", Email = "babbo@gmail.com"},
        new Employee{ Id = 1767, Name = "Wiggo", Email = "wigowigo@gmail.com"},
        ];
    private int NextId => employees.Max(e => e.Id) + 1;

    public Employee GetEmployeeById(int id)
    {
        var employee = employees.SingleOrDefault(e => e.Id == id);

        return employee;
    }

    public Employee[] GetAllEmployees() => employees.ToArray();

    public bool AddEmployee(Employee employee)
    {
        employee.Id = NextId;
        if (!(GetEmployeeById(employee.Id) == null))
            return false;
        if (employees.Any(e => e.Email == employee.Email))
            return false;
        employees.Add(employee);
        return true;

    }

    public bool DeleteEmployee(int id)
    {
        if ((GetEmployeeById(id) == null))
            return false;
        employees.Remove(GetEmployeeById(id));
        return true;
    }
}

