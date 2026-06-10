Employee e1 = new Employee();
//e1 is a reference pointing to that object.
e1.name = "Alice";
e1.age = 30;
Console.WriteLine("\nTop level statementss and not nullable strings:");
Console.WriteLine("{0}, {1}", e1.name, e1.age);

Console.WriteLine("\nProperties:");
Student s1 = new Student();
//s1 is a reference pointing to that object.
s1.name = "Alice";
s1.age = 30;
Console.WriteLine("{0}, {1}", s1.name, s1.age);

Console.WriteLine("Constructor:");
Person p1 = new Person();
Console.WriteLine(p1.age);
Console.WriteLine(p1.name);

Console.WriteLine("\nEncapsulation:");
BankAccount acc1 = new BankAccount();
acc1.Balance = 1000; // Valid
acc1.Balance = -500; // Rejected by setter
Console.WriteLine("Balance: " + acc1.Balance);

Console.WriteLine("\nInheritance and Polymorphism:");
OffEmployee emp1 = new OffEmployee();
emp1.name = "Bob"; // Inherited from Person class
emp1.Company = "Developer"; // public property defined in OffEmployee to access private field 'company'
Console.WriteLine("Name: " + emp1.name);
Console.WriteLine("Company: " + emp1.Company);

Console.WriteLine("\nMethod Overriding:");
/**
OffEmployee emp2 = new OffEmployee();
emp2 = new Person(); // Creates a new Person object

Error: Cannot implicitly convert type 'Person' to 'OffEmployee'. An explicit conversion exists (are you missing a cast?)
Reason: emp2 is ONLY allowed to hold OffEmployee objects (or its children).
Solution: Use a base class reference to hold the object.
**/

Person p2 = new OffEmployee();
p2.age = 25; // Inherited from Person class
Console.WriteLine("case 1: Person class object decalred and Employee object assigned: " + p2.CalculateBirthYear()); // Calls overridden method in OffEmployee class

p2 = new Person(); // Creates a new Person object
Console.WriteLine("case 2: Reassigned Person object to previous reference of Person class: " + p2.CalculateBirthYear()); // Calls the base class method

Person p3 = new Person();
p3=p2; // p3 now references the same object as p2, which is a Person object
Console.WriteLine("case 3: New Person class object declared and previous Person object copied: " + p3.CalculateBirthYear()); // Calls the base class method, since p3 references a Person object

p3 = new OffEmployee();
Console.WriteLine("case 4: New OffEmployee object assigned to Person reference: " + p3.CalculateBirthYear()); // Calls the overridden method in OffEmployee class,

Person p4 = new OffEmployee();
p4=p2; // p4 now references the same object as p2, which is a Person object
Console.WriteLine("case 5: Person class object declared and Person object assigned: " + p4.CalculateBirthYear()); // Calls the base class method, since p4

/**
Output:
case 1: Person class object decalred and Employee object assigned: Eligible for job application
case 2: Reassigned Person object to previous reference of Person class: Birth year: 2026
case 3: New Person class object declared and previous Person object copied: Birth year: 2026
case 4: New OffEmployee object assigned to Person reference: Eligible for job application
case 5: Person class object declared and Person object assigned: Birth year: 2026
**/

/**
In C#, classes are reference types. 
Assignment does not create a new object; it only copies the reference, meaning multiple variables can point to the same object in memory.
Object lives in heap:
[ OffEmployee OBJECT in HEAP ]
        ↑
        |
      p2
        |
      p3   (same address)

**/

Console.WriteLine("\nInterfaces:");
IAnimal Dog = new Dog();
Dog.MakeSound(); // Output: Bark
IAnimal Cat = new Cat();
Cat.MakeSound(); // Output: Meow

IAnimal[] animal = {new Dog(), new Cat()};
foreach(IAnimal a in animal){
    a.MakeSound();
}

Console.WriteLine("\nAbstract Classes:");
Mouse m = new Mouse();
m.MakeSound(); // Output: Squeak

Animal a1 = new Mouse();
a1.Sleep(); // Output: Sleeping

//Animal a2 = new Animal(); 
// Error: Cannot create an instance of the abstract class 'Animal'

//Animal.Sleep(); 
// Error: An object reference is required for the **non-static** field, method, or property 'Animal.Sleep()'