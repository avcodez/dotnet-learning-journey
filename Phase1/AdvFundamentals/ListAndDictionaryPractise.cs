class ListAndDictPractise
{
    public static void ListQue()
    {
        Console.WriteLine("Q1 + Q2: Add 5 employees and print them");
        //Employee emp = new Employee(); - Trial
        List<Employee> empList = new List<Employee>();
        empList.Add(new Employee("Alice", 23));
        empList.Add(new Employee("Bob", 45));
        empList.Add(new Employee("Casey", 15));
        empList.Add(new Employee("Donna", 20));
        empList.Add(new Employee("Easther", 35));

        foreach (Employee e in empList)
        {
            Console.WriteLine(e.Name + " age: " + e.Age);
        }
        /**
        bool result = empList.Remove(item);
        returns:
        true  -> item found and removed
        false -> item not found
    
        List<Employee> empList = new List<Employee>();
        empList.Add(new Employee("Alice", 23));
        empList.Add(new Employee("Bob", 45));
        Employee emp = new Employee("Alice", 23);
        empList.Remove(emp);
    
        Object A -> Alice, 23
        Object B -> Bob, 45
    
        Now later:
        Employee emp = new Employee("Alice", 23);
        creates:
        Object C -> Alice, 23
        Even though the data is identical:
        Object A != Object C
    
        Result: Nothing removed.
        **/
        Employee emp = new Employee("Alice", 23);

        empList.Remove(emp);
        //In the above statment nothing was actuall removed and result is false because emp is a seaprate object refer above comment for more info
        foreach (Employee e in empList)
        {
            Console.WriteLine(e.Name + " age: " + e.Age);
        }

        empList.RemoveAt(0);
        foreach (Employee e in empList)
        {
            Console.WriteLine(e.Name + " age: " + e.Age);
        }
        Console.WriteLine("Count: " + empList.Count());
        Console.WriteLine("IsEmpty: " + (empList.Count() == 0));
    }

    public static void DictQue()
    {
        Console.WriteLine("Hello from dict");
        Dictionary<int, Employee> d = new Dictionary<int, Employee>();
        //Dictionary expects Key Value Pair
        d.Add(101, new Employee("ALice", 23));
        d.Add(102, new Employee("Bob", 24));
        d.Add(103, new Employee("Casey", 25));
        d.Add(104, new Employee("Donna", 26));
        d.Add(105, new Employee("Easther", 27));

        Console.WriteLine(d[102]);
        //Result = Employee (Object name)
        Console.WriteLine(d[102].Name);
        Console.WriteLine(d.ContainsKey(107));
        Console.WriteLine(d.Remove(101));
        foreach (var i in d)
        {
            //Console.WriteLine(i.Key+" "+i.Value);
            // Above returns result as 102 Employee
            Console.WriteLine(i.Key + " " + i.Value.Name + " " + i.Value.Age);
        }
    }
}

/**
List Questions:
Add 5 employees
Print all employees
Remove 1 employee
Print Count
Check if list is empty

Dictionary Questions:
Add 5 employees
Retrieve employee 102
Check ContainsKey
Remove employee 101
Print all entries
**/
