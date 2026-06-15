var ip = true;
EmployeeManage empMg = new EmployeeManage();
while (ip)
{
    try
    {
        Console.WriteLine("Employee Management Console Menu:");
        Console.WriteLine("1. Show All Employee");
        Console.WriteLine("2. Add Employee");
        Console.WriteLine("3. Search Employee by Id");
        Console.WriteLine("4. Remove Employee");
        Console.WriteLine("5. Show Employee older than 25");
        Console.WriteLine("6. Print Names");
        Console.WriteLine("7. Check All Adults");
        Console.WriteLine("8. Exit");

        int choice = int.Parse(Console.ReadLine()!);

        //The ! tells the compiler: this won't be null.

        //EmployeeManage empMg = new EmployeeManage();
        //It should not be declared here coz, object is getting created every iteration.

        switch (choice)
        {
            case 1:
                empMg.ShowEmployee();
                break;
            case 2:
                empMg.AddEmployee(new Employee(103, "Fanny", 45));
                /**
                Warning: Duplicate Employee IDs
                You are doing: employees.Add(new Employee(103, "Casey", 21));
                and later: empMg.AddEmployee(new Employee(103, "Fanny", 45));
                Real systems should prevent this.

                Example:
                if(employees.Any(e => e.Id == eNew.Id))
                {
                    Console.WriteLine("Employee ID already exists");
                    return;
                }
                **/
                break;
            case 3:
                empMg.FindEmployeeId(104);
                break;
            case 4:
                empMg.RemoveEmployee(new Employee(104, "Donna", 45));
                break;
            case 5:
                empMg.ShowEmployeesOlderThan25();
                break;
            case 6:
                empMg.PrintNames();
                break;
            case 7:
                empMg.DisplayAdults();
                break;
            case 8:
                //Exit option does not exit.
                break;
            default:
                break;
        }
        Console.WriteLine("Do you want to continue: Press 1 to contiue else 0 for no");
        int ans = int.Parse(Console.ReadLine());
        if (ans == 1)
        {
            ip = true;
        }
        else
        {
            ip = false;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Invalid input: " + ex.Message);
    }
}
