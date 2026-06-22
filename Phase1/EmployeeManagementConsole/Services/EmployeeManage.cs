class EmployeeManage
{
    private List<Employee> employees = new List<Employee>();

    public EmployeeManage()
    {
        employees.Add(new Employee(101, "Alice", 25));
        employees.Add(new Employee(102, "Bob", 28));
        employees.Add(new Employee(103, "Casey", 21));
        employees.Add(new Employee(104, "Donna", 56));
        employees.Add(new Employee(105, "Esther", 34));
    }

    public void AddEmployee(Employee e)
    {
        employees.Add(e);
        Console.WriteLine($"Employee Added successfully: {e.Name}");
    }

    public void ShowEmployee()
    {
        foreach (var emp in employees)
        {
            Console.WriteLine($"Employee {emp.Id} iis {emp.Name} with age {emp.Age}");
        }
    }

    public void FindEmployeeId(int Id)
    {
        /**
        var findid = employees.Where(e => e.Id == Id).Select(e => e.Name);
        Console.WriteLine($"Employee found {findid[0]}");

        Issue:
        Where().Select() returns an IEnumerable<string>, not a list or array.
        findid[0] won't work because IEnumerable<T> doesn't support indexing.

        If we want to use this logic then need to convert it to List first

        var findid = employees.Where(e => e.Id == Id).Select(e => e.Name).ToList();
        Console.WriteLine($"Employee found {findid[0]}");
        **/

        string? employeeName = employees
            .Where(e => e.Id == Id)
            .Select(e => e.Name)
            .FirstOrDefault();
        /**
        This works: employees.Where(...).Select(...).FirstOrDefault();
        But in real code we'd write:
        var employee = employees.FirstOrDefault(e => e.Id == Id);
        because you need the whole Employee.
        **/

        if (employeeName != null)
        {
            Console.WriteLine($"Employee found: {employeeName}");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }

    public void RemoveEmployee(Employee emp)
    {
        var empFound = employees.FirstOrDefault(e => e.Id == emp.Id);
        if (empFound != null)
        {
            employees.Remove(empFound);
            Console.WriteLine($"Employee removed {empFound.Name}");
        }
        else
        {
            Console.WriteLine("Employee not present");
        }
    }

    //     Console.WriteLine("5. Show Employee older than 25");
    // Console.WriteLine("6. Print Names");
    // Console.WriteLine("7. Check All Adults");

    public void ShowEmployeesOlderThan25()
    {
        var listOlder25 = employees.Where(e => e.Age > 25);
        Console.WriteLine("Employee older than 25:");
        foreach (var item in listOlder25)
        {
            Console.WriteLine($"{item.Id}, {item.Name}, {item.Age}");
        }
    }

    public void PrintNames()
    {
        var nameList = employees.Select(e => e.Name);
        foreach (var item in nameList)
        {
            Console.WriteLine($"{item}");
            //not {item.Name} as nameList is IEnumerable of string
        }
    }

    public void DisplayAdults()
    {
        //Below line is not accurate as we wants to display **all** adult
        var AdultList = employees.Where(e => e.Age >= 18);
        bool allAdults = employees.All(e => e.Age >= 18);
        if (allAdults)
        {
            Console.WriteLine("All are adults");
        }
        else
        {
            Console.WriteLine("Not all are adults");
        }
        foreach (var item in AdultList)
        {
            Console.WriteLine($"{item.Name}");
        }
    }
}
