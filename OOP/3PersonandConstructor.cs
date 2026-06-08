//What is a Constructor?: A constructor is a special method that runs automatically when an object is created.
// Same name as class, no return type, can be parameterized or non-parameterized.

public class Person {
    public string name;
    public int age;


    //Default constructor
    public Person(){
        name = "Unknown";
        age = 0;
    }

    // Parameterized constructor
    // Warning: Assignment made to same variable; did you mean to assign something else?
    // Field 'Person.name' is never assigned to, and will always have its default value null
    public Person(string name, int age){
        name = name;
        this.age = age;
    }

    //Constructor overloading
    public Person(string name){
        this.name = name;
        age = 0;
    }
    
    //virtual: Allows a method to be overridden.
    public virtual string CalculateBirthYear(){
        return $"Birth year: {DateTime.Now.Year - age}";
    }

}

/**
this keyword:
 public Person(string name, int age){
        name = name;
        this.age = age;
    }

Warning: Assignment made to same variable; did you mean to assign something else?
Field 'Person.name' is never assigned to, and will always have its default value null

Result: p1.name is null
 
Reason:
this.Name → class member
Name → constructor parameter

this is required only when a class member (field/property) and a local variable/parameter have the same name. Otherwise, it is optional.
**/