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