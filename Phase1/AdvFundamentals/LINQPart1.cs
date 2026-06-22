class Linq
{
    public static void WhylinqQue()
    {
        Console.WriteLine("Hello from linq");
        // List<Employee> employees = ...
        // Write a loop to:
        // Find Alice
        // Find all employees older than 25
        // Check if any employee is older than 50
        // Print only employee names
        // Use only foreach and if.

        List<Employee> emp = new List<Employee>();
        emp.Add(new Employee("Alice", 26));
        emp.Add(new Employee("Bob", 28));
        //Below initilization requires a parameterless constructor as first it initialises object like new Employee(); then assigns value to properties.
        emp.Add(new Employee { Name = "Casey", Age = 21 });
        emp.Add(new Employee("Donna", 56));
        emp.Add(new Employee { Name = "Easther", Age = 34 });
        bool AnyoneAbove50 = false;
        foreach (var e in emp)
        {
            if (e.Name == "Alice")
            {
                Console.WriteLine($"Alice is found with age {e.Age}");
            }
            if (e.Age > 25)
            {
                Console.WriteLine($"{e.Name} is found with age > 25 and age is {e.Age}");
            }
            if (e.Age > 50)
            {
                AnyoneAbove50 = true;
            }
        }
        Console.WriteLine($"Anyone above 50 ? {AnyoneAbove50}");
        foreach (Employee e in emp)
        {
            Console.WriteLine(e.Name);
        }
    }

    /**Notice the pattern?
    Loop
        ↓
    Condition
        ↓
    Do something

    You keep writing the same boilerplate. LINQ was created to make querying collections easier.

    What is LINQ? LINQ = Language Integrated Query
    It allows you to query collections using methods instead of manually writing loops.
    **/
    public static void linqUse()
    {
        /**
        Modern .NET projects often enable Implicit Usings. (Present in .csproj file)
        LINQ extension methods belong to System.Linq.

        In older projects we must add:
        using System.Linq;

        In modern .NET projects, ImplicitUsings may automatically import System.Linq,
        so LINQ works without explicitly writing the using statement.
        **/
        List<Employee> emp = new List<Employee>();
        emp.Add(new Employee("Alice", 26));
        emp.Add(new Employee("Bob", 28));
        emp.Add(new Employee("Casey", 21));
        emp.Add(new Employee("Donna", 56));

        //*******1) Where Clause*******

        //e=> called lambda expression and below statement creates a filtered collection
        //We need to use System.Linq namespace otherwise LINQ statements won't work
        var result1 = emp.Where(e => e.Age > 25);
        var result2 = emp.Where(e => e.Age < 30);

        // Where() returns IEnumerable<Employee>.

        // The filtering rule is stored but not executed immediately.
        // Execution happens when the sequence is enumerated (foreach, ToList, First, etc.).
        // This behavior is called Deferred Execution.
        emp.Add(new Employee("Easther", 40));
        Console.WriteLine("LINQ result deferred execution:");
        //Easther included despite being added later as it's a deferred execution
        foreach (var item in result1)
        {
            Console.WriteLine(item.Name);
        }
        Console.WriteLine("LINQ result 2 deferred execution:");
        foreach (var item in result2)
        {
            Console.WriteLine(item.Name);
        }
        //How To Force a List If you want an actual List:

        List<Employee> result = emp.Where(e => e.Age > 25).ToList();
        emp.Add(new Employee("Fanny", 32));
        // Fanny is not included as it's a immediate execution

        Console.WriteLine("LINQ Tolist (Immediate execution) result:");
        foreach (var item in result)
        {
            Console.WriteLine(item.Name);
        }

        //*******2)First() or FirstOrDefault()*******
        /**
        Where Clause returns IEnumerable

        First() - Returns the first element that satisfies the condition
        First() - returns a single matching element.
        Since emp is List<Employee>, the return type is Employee. Unlike Where(), it does not return IEnumerable<Employee>.

        If the result is not present then it can cause Runtime Exception:
        InvalidOperationException
        Sequence contains no matching element

        Reason: First() assumes that "There must be at least one match."

        So we have safer version:
        FirstOrDefault() which returns null/0 (basically the default value for given data type) if no result is present
        Reference types (Employee, string, List<Employee>) -> null
        Value types:
        int -> 0
        bool -> false
        double -> 0
        DateTime -> default(DateTime)

        Assignment:
        Q1 Find Alice using First() and print her age.

        Q2 Find Bob using FirstOrDefault() and print his age.

        Q3 Search for John using FirstOrDefault().
        If result is null:
        Employee not found
        otherwise print the name.

        Q4 Search for John using First().
        Wrap it in:
        try {}
        catch(Exception ex) { }

        Print:
        ex.Message

        **/
        var res = emp.First(e => e.Name == "Alice");
        Console.WriteLine("Question 1: Alice Age = " + res.Age);

        //Warning for below statement: Dereference of a possibly null reference.
        //Means {emp.FirstOrDefault(e => e.Name == "Bob")} can be null
        //and accessing .Age on a null object would throw NullReferenceException.
        //Console.WriteLine($"Question 2: Bob Age = {emp.FirstOrDefault(e => e.Name == "Bob").Age}");

        //Better Version:
        res = emp.FirstOrDefault(e => e.Name == "Bob");
        if (res != null)
        {
            Console.WriteLine($"Question 2: Bob Age = {res.Age}");
        }

        Console.WriteLine("Question 3");
        res = emp.FirstOrDefault(e => e.Name == "John");
        if (res == null)
        {
            Console.WriteLine("Employee Not Found");
        }
        else
        {
            Console.WriteLine("Emp name =" + res.Name);
        }

        Console.WriteLine("Question 4:");
        try
        {
            res = emp.First(e => e.Name == "John");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.StackTrace}");
        }

        /******Note******

        Use First() when you are certain a matching record exists.
        Use FirstOrDefault() when a matching record may or may not exist.

        ******Note******/
    }
}
