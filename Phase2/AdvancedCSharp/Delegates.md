Topics covered:
Why delegates exist
Method references
Creating a custom delegate
Passing methods as parameters
Comparing hardcoded behavior vs delegate-based behavior
Relationship between custom delegates and Action

Step 1: Life Without Delegates

Suppose you have:

void SayHello() { Console.WriteLine("Hello"); }
void SayBye() { Console.WriteLine("Bye"); }

You call them directly:
SayHello();
SayBye();

For normal situations, you do not need delegates.

Step 2: Imagine You Want Generic Code

Suppose you write:

void DoSomething()
{
    Console.WriteLine("Before work");

    // ??? Which method should execute here?

    Console.WriteLine("After work");
}

Now imagine different people want different work.

Person 1 wants: SayHello();
Person 2 wants: SayBye();

How can DoSomething() know which method to run?

You could write:

void DoSomething(string operation)
{
    Console.WriteLine("Before");
    if (operation == "Hello")
        SayHello();
    if (operation == "Bye")
        SayBye();
    Console.WriteLine("After");
}

Usage:
DoSomething("Hello");
DoSomething("Bye");

Works. But what if tomorrow you add:
PrintAge();
SendEmail();
SaveToDatabase();

You'll keep changing DoSomething(). That's bad design.

Step 3: Better Solution

Instead of passing strings:
Pass the actual method.

Think:
"Dear DoSomething,
you don't decide the work.
I'll give you the method to execute."

Example:

DoSomething(SayHello);
DoSomething(SayBye);

Now DoSomething becomes:

void DoSomething( ??? action )
{
    Console.WriteLine("Before");
    action(); // Execute whatever was passed
    Console.WriteLine("After");
}

Question:

How do we tell C# that action is a method?

Answer: Delegate.

delegate void MyDelegate();

Now:

void DoSomething(MyDelegate action)
{
    Console.WriteLine("Before");
    action();
    Console.WriteLine("After");
}

Usage:
DoSomething(SayHello);

Output:
Before
Hello
After

or

DoSomething(SayBye);

Output:
Before
Bye
After

DoSomething() never changes.
New behavior can be added without modifying existing code.
Code becomes reusable and extensible.

This follows the Open/Closed Principle from SOLID:

Software entities should be open for extension but closed for modification.

-----------------------------------------------------------------------

Custom Delegate
---------------
I create my own delegate type.

delegate void PrintDelegate();
Execute(PrintDelegate printer)

Built-in Delegate
-----------------
Microsoft has already created common delegates.

Action          -> void, no return
Action<T>       -> void, with parameters
Func<T>         -> returns a value
Predicate<T>    -> returns bool

Instead of creating: delegate void PrintDelegate();

I simply use: Action

***Interview***
Without delegates, a method often hardcodes which methods it will call using conditions like if or switch. Every time new behavior is added, that method must be modified. Delegates solve this by allowing methods to be passed as parameters. The caller chooses the behavior, while the receiving method simply invokes it. This makes the code more reusable and aligns with the Open/Closed Principle. In modern C#, we usually use the built-in delegates Action, Func, and Predicate instead of creating custom delegates unless a custom delegate name improves readability or expresses domain-specific intent.


Based on what you've learned so far, what do you think will happen if one method in the multicast delegate throws an exception before the remaining methods are executed? Think it through before trying it—that behavior is important and often comes up in interviews.