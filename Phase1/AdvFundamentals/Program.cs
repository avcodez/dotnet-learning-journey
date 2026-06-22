/**What is an Exception? An exception is a runtime error that breaks normal program flow.

Without exception handling, the program would crash when an error occurs.
With exception handling, you can catch and handle errors gracefully, allowing the program to continue running or exit cleanly.

try → catch → finally → throw

Try: Wraps code that may throw an exception.
Catch: Handles the exception if it occurs.
Finally: Code that always executes, regardless of whether an exception was thrown or caught.
throw: manually trigger an exception.

1) Specific Exception Handling: Catch specific exceptions to handle known error conditions.
2) Multiple Catch Blocks: Use multiple catch blocks to handle different types of exceptions separately.
3) Exception properties: Use properties like Message, StackTrace, and InnerException to get more information about the error.
4) Custom Exceptions: Create your own exception classes by inheriting from the base Exception class to represent specific error conditions in your application.
5) Rethrowing Exceptions: You can catch an exception, perform some logging or cleanup,
**/

try
{
    int a = 10;
    int b = 0;
    int result = a / b;
    int[] arr = new int[5];
    arr[7] = 10; // Index out of range
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Array index error: " + ex.Message);
    Console.WriteLine("Stack Trace: " + ex.StackTrace);
    Console.WriteLine("Inner Exception: " + ex.InnerException);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Math error: " + ex.Message);
    Console.WriteLine("Stack Trace: " + ex.StackTrace);
    Console.WriteLine("Inner Exception: " + ex.InnerException);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    Console.WriteLine("Always executes");
    /**
    Useful for:
    Closing files
    Closing DB connections
    Releasing resources
    **/
    //Objects in memory → Garbage Collector handles them.
    /**
    External resources (files, DB connections, streams, sockets) → You must release them using:
    Dispose()/Close()/using/finally

    Otherwise your application can leak resources, lock files, or exhaust database connections.
    This becomes especially important in ASP.NET Core applications where thousands of requests may be opening files and database connections every minute.
    **/
    //When the using block ends, C# automatically calls Dispose(), which releases the resource safely.
}

//throw new Exception("Custom error message");

Console.WriteLine("\nLists");
List<Employee> employees = new List<Employee>();
Console.WriteLine("List of objects and how constructors work:"); // Output: Count: 0

/**
1) Add objects to the list using object initializer syntax

employees.Add(new Employee { name = "Alice", age = 30 });
employees.Add(new Employee { name = "Bob", age = 25 });

    Flow of execution: [It is roughly converted by the compiler into]
    1. new Employee() creates a new Employee object in memory. [Employee temp = new Employee();]
    2. The object initializer syntax { name = "Alice", age = 30 } sets the properties of the Employee object. [temp.Name = "Alice"; temp.Age = "30";]
    3. The fully initialized Employee object is then added to the employees list using the Add() method. [employees.Add(temp);]

Private members are accessible only inside the class.
So outside the class:
new Employee { name = "Alice" }
❌ Compilation Error
**/

/**
2) Add objects using Constructor Initialization syntax

employees.Add(new Employee("Alice",24));

new Employee("Alice", 30)
        ↓
Constructor executes
        ↓
name = Alice
age = 30
**/
employees.Add(new Employee("Alice", 24));

//Signature for Add method: public void Add(Employee item)
//You're adding one Employee into a collection of Employees.

Console.WriteLine(employees[0].Name); // Output: Alice
Console.WriteLine(employees[0].Age); // Output: 30

//employees.Add(emp);
//employees.Remove(emp);
//employees.RemoveAt(0);
//employees.Count;
//employees.Contains(emp);
//employees[0];
//foreach(var emp in employees)
//{
//}

Console.WriteLine("\nDictionaries");
Dictionary<int, string> emp = new Dictionary<int, string>();
emp.Add(101, "Mike");
emp.Add(102, "Steve");

//Signature for Add method: public void Add(TKey key, TValue value)
//Each entry is actually a pair.
//C# chose Add(key, value) instead of Add(new KeyValuePair<int,string>(101,"Mike")) for simplicity
//You can actually do var pair = new KeyValuePair<int, string>(101, "Mike");

/**
Why Not This for list? employees.Add("Alice", 24);
Because a List stores one item type.

The list expects: Employee not two separate values.

C# doesn't know how to convert: "Alice", 24 into an Employee automatically.

So you must create the Employee first: new Employee("Alice", 24) and then add it.
----------------------------------------------------------------------------------
A List stores: [Employee][Employee][Employee] so Add receives one Employee.

A Dictionary stores:
[Key -> Value]
[Key -> Value]
[Key -> Value]
so Add receives a key and a value.

The Add method is designed according to what the collection stores.
**/

Console.WriteLine(emp[102]);
emp.Add(103, "Harvey");

Console.WriteLine(emp[101]);
Console.WriteLine(emp.ContainsKey(103));

emp.Remove(101);
Console.WriteLine("\nFinal Dictionary:");
foreach (var item in emp)
{
    Console.WriteLine(item.Key);
    Console.WriteLine(item.Value);
}

ListAndDictPractise.ListQue();
ListAndDictPractise.DictQue();
Linq.WhylinqQue();
Linq.linqUse();
Linq2.linqQue2();
