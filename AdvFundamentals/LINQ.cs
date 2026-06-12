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
        List<Employee> emp = new List<Employee>();
        emp.Add(new Employee("Alice", 26));
        emp.Add(new Employee("Bob", 28));
        emp.Add(new Employee("Casey", 21));
        emp.Add(new Employee("Donna", 56));

        //1) Where Clause
        //e=> called lambda expression and below statement creates a filtered collection
        //We need to use System.Linq namespace otherwise LINQ statements won't work
        var result1 = emp.Where(e => e.Age > 25);
        var result2 = emp.Where(e => e.Age < 30);
        // Where() returns IEnumerable<Employee>.
        // The filtering rule is stored but not executed immediately.
        // Execution happens when the sequence is enumerated (foreach, ToList, First, etc.).
        // This behavior is called Deferred Execution.
        foreach (var item in result1)
        {
            Console.WriteLine(item.Name);
        }
        foreach (var item in result2)
        {
            Console.WriteLine(item.Name);
        }
        //How To Force a List If you want an actual List:

        List<Employee> result = emp.Where(e => e.Age > 25).ToList();
        /**
        Modern .NET projects often enable Implicit Usings. (Present in .csproj file)
        LINQ extension methods belong to System.Linq.

        In older projects we must add:
        using System.Linq;

        In modern .NET projects, ImplicitUsings may automatically import System.Linq,
        so LINQ works without explicitly writing the using statement.
        **/
    }
}
