/**
An interface is a contract that defines what a class must do without specifying how it does it. 
Any class implementing the interface must provide implementations for all its members.

Interfaces typically start with I by convention.
Interface methods are declared without implementation.

Interface members are implicitly public and abstract. 
Therefore, classes implementing an interface must provide public implementations of all interface members.

Why Use Interfaces?

Interfaces allow unrelated classes to share common capabilities.

Example:

Duck CAN Fly
Airplane CAN Fly
Bird CAN Fly

C# does not support multiple inheritance of classes:

class Child : Parent1, Parent2 // ❌ Not Allowed
{
}

But it supports multiple interfaces:
class Duck : IFlyable, ISwimmable
{
}

Real .NET Usage

Interfaces are heavily used in:

Dependency Injection (DI)
Logging (ILogger)
Repositories (IRepository)
Services (IEmailService)
Collections (IEnumerable)
**/

interface IAnimal
{
    //Because interface members are implicitly public and abstract.
    //Compiler treats it as : public abstract void MakeSound();
    void MakeSound(); // Method declaration without implementation
}

class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}

class Cat : IAnimal{
/**
Error:'Cat' does not implement interface member 'IAnimal.MakeSound()'. 
'Cat.MakeSound()' cannot implement an interface member because it is not public.

Reason: void MakeSound(){} private by default, but interface members must be public.
**/
    public void MakeSound(){
        Console.WriteLine("Meow");
    }
}

//*****ABSTRACT CLASSES*****

/**
An abstract class is a partially implemented class that (some ready code + some contracts):

❌ cannot be instantiated (you cannot create its object)
✅ can contain both abstract methods (no body) and normal methods (with body - Child can directly use it)
✅ is meant to be a base class for inheritance + Must be implemented in child class

🔷 1. Why can’t we create object of abstract class? Because it is incomplete.

abstract class Animal
{
    public abstract void MakeSound();
}

Now if I create Animal object, what will MakeSound() do? Answer: Nothing (no implementation)

So C# says: ❌ “You are not allowed to create something incomplete”

🔷 2. Why do we need abstract methods?

Abstract class provides partial abstraction, allowing both abstract and concrete methods, 
while interfaces provide full abstraction (contract only).

❌ Without abstract class and Only interface:

interface IAnimal { void MakeSound(); }

Problem: You CANNOT write shared logic

Example: 
Every animal sleeps the same way
But interface forces every class to rewrite it again ❌

✔ With abstract class
abstract class Animal
{
    public void Sleep()
    {
        Console.WriteLine("Sleeping...");
    }
    public abstract void MakeSound();
}

Now:
✔ shared logic (Sleep)
✔ required logic (MakeSound)
**/

abstract class Animal{
    public abstract void MakeSound();
    public void Sleep(){
        Console.WriteLine("Sleeping...");
    }
}

class Mouse : Animal{
    //override is used when a child class changes the implementation of a method that already exists in the parent class.
    public override void MakeSound(){
        Console.WriteLine("Squeak");
    }
}