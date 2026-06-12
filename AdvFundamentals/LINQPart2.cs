class Linq2
{
    public static void linqQue2()
    {
        List<Employee> emp = new List<Employee>();
        emp.Add(new Employee("Alice", 26));
        emp.Add(new Employee("Bob", 28));
        emp.Add(new Employee("Casey", 21));
        emp.Add(new Employee("Donna", 56));

        /**********3) Any Clause************
        A lot of code for a simple yes/no question.
        It returns bool value - true or false
        
        Why Not Use FirstOrDefault()?
        You could write:
        var employee = emp.FirstOrDefault(e => e.Name == "Alice");
        if(employee != null) { // found }

        But if you only need to know whether it exists, not the employee itself:
        bool exists = emp.Any(e => e.Name == "Alice");
        is cleaner.

        As soon as LINQ finds one matching employee, it stops searching rest - performance benefit

        Use case:
        bool exists = users.Any(u => u.Email == email);
        if (exists)
        {
            Console.WriteLine("Email already exists");
        }
        

        Q1 Check if any employee is older than 50.
        Print: True or False

        Q2 Check if any employee is named Alice.

        Q3 Check if any employee is named John.

        Q4 Replace this old code with a single LINQ statement using Any():
        bool found = false;
        foreach(var e in emp)
        {
            if(e.Name == "Alice")
            {
                found = true;
                break;
            }
        }
        **/

        Console.WriteLine($"Que 1: {emp.Any(e => e.Age > 50)}");
        Console.WriteLine($"Que 2: {emp.Any(e => e.Name == "Alice")}");
        Console.WriteLine($"Que 3: {emp.Any(e => e.Name == "John")}");
        Console.WriteLine($"Que 4: {emp.Any(e => e.Name == "Alice")}");

        //One more form of Any() :
        Console.WriteLine($"Does this collection contain at least one item? {emp.Any()}");
        //This is equivalent to: emp.Count > 0 or emp.Count() > 0

        /**********4) Select Clause************

        Select() is used to transform data.
        Select() changes the shape of records.
        
        Without LINQ:
        List<string> names = new List<string>();
        foreach(var e in emp)
        {
            names.Add(e.Name);
        }

        Select() replaces this pattern.
        The return type of Select() depends on what is selected.
        
        Examples:
        emp.Select(e => e.Name)
        Returns: IEnumerable<string>

        emp.Select(e => e.Age)
        Returns: IEnumerable<int>

        emp.Select(e => e)
        Returns: IEnumerable<Employee>

        Q1 Create a collection containing only names.
        Print:
        Alice
        Bob
        Donna
        
        Q2 Create a collection containing only ages.
        Print:
        26
        28
        56

        Q3 Combine Where() and Select(): Get names of employees older than 30.
        Expected:
        Donna

        Q4 Predict the type: var result = emp.Select(e => e.Name);

        Is it:
        Employee / List<Employee> / IEnumerable<Employee> / string / IEnumerable<string>
        and explain why.
        **/

        Console.WriteLine("Que 1:");
        var coll = emp.Select(e => e.Name);
        foreach (var i in coll)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Que 2:");
        var coll2 = emp.Select(e => e.Age);
        foreach (var i in coll2)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Que 3:");
        coll = emp.Where(e => e.Age > 30).Select(e => e.Name);
        foreach (var i in coll)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Que 4: result will be Ienumerable of string");
        var result = emp.Select(e => e.Name);
        Console.WriteLine(result);

        /**********5) All() Clause************
        Do all match the condition?

        Real ASP.NET Core Example:
        Check if all users are verified:
        bool verified = users.All(u => u.IsVerified);

        Check if all employees are adults:
        bool adults = employees.All(e => e.Age >= 18);
        ------------------------------------------------------------
        Q1 Check if all employees are older than 18.
        Expected: True
        
        Q2 Check if all employees are older than 30.
        Expected: False
        
        Q3 Check if all employee names start with a capital letter.
        Hint: char.IsUpper(...)
        Expected: True

        Q4 Explain the difference: emp.Any(e => e.Age > 50)
        vs emp.All(e => e.Age > 50) in one sentence.
        **/

        Console.WriteLine("Que 1: " + emp.All(e => e.Age > 18));
        Console.WriteLine("Que 2: " + emp.All(e => e.Age > 30));
        Console.WriteLine("Que 3: " + emp.All(e => char.IsUpper(e.Name[0])));
        Console.WriteLine("Que 4: Any means at least one and all means every item satisfy");
    }
}
