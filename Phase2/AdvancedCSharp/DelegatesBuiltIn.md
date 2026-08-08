
Step 1: The Problem

Suppose you write:
delegate void PrintDelegate();

Later you need another delegate.
Later another ...
Later another ...

delegate void PrintDelegate();
delegate void SaveDelegate();
delegate void EmailDelegate();
delegate void LogDelegate();

Notice something?

All of them have the same signature, returns void and takes no parameters. 
The only thing changing is the delegate name.

Microsoft noticed this too. The .NET team realized developers were repeatedly writing delegates. 
So they proivded common built in delegate types in the .NET Framework itself, which are Action, Func, and Predicate.

1) Action: Action is a built-in delegate used for methods that do not return a value (void).
    Suppose you have
    public static void SaveFile() { .... }
    
    Using a custom delegate:
    delegate void Operation();
    Operation op = SaveFile;
    op();

    Using Action:
    Action action = SaveFile;
    action();

    Exactly the same result.

    Why use Action? Because you don't have to write "delegate void Operation();" every time. That's it.

2) Action<T>: It is a built-in generic delegate that represents methods returning void and accepting one or more input parameters.
    It was introduced to eliminate the need to create custom delegates for common method signatures that return void.
    The pattern continues (up to 16 input parameters in .NET).

    1] Single Parameter:
    void PrintAge(int age)
    {
        Console.WriteLine(age);
    }
    Action<int> action = PrintAge;
    action(25);

    2] Multiple Parameter:
    void PrintEmployee(string name, int age)
    {
        Console.WriteLine($"{name} {age}");
    }

    //Custom delegate
    delegate void EmployeeDelegate(string name, int age);

    //Built-In Delegate
    Action<string, int> employee = PrintEmployee;

    //Invoke
    employee("Alex", 30);

    Delegate	        Parameters	Return
    Action	            0	        void
    Action<T>	        1	        void
    Action<T1,T2>	    2	        void
    Action<T1,T2,T3>	3	        void

    Notice that only the number and types of parameters change. The return type is always void.

    ASP.NET Core Relevance:
    You'll frequently encounter Action<T> in ASP.NET Core configuration APIs.
    For example:

    services.Configure<MyOptions>(options =>
    {
        options.Name = "Demo";
    });

    Conceptually, Configure accepts an Action<MyOptions>—a method that receives a MyOptions object and returns void.

3) Func/Func<TResult>: 
    Why Func Exists
    Microsoft created another built-in delegate.nIts job is simple.
    Represent methods that return a value. That's Func.
    
    Methods returning void --> Action
    Methods returning something --> Func

    Without function:
    delegate int Operation();
    Operation operation = Add;

    With Func:
    Func<int>