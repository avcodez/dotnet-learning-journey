
//Inheritance allows a child class to reuse the fields, properties, and methods of a parent class, reducing code duplication and promoting reusability.
/**
Type	C# Support
Single Inheritance	✅ Yes
Multilevel Inheritance	✅ Yes
Hierarchical Inheritance	✅ Yes
Multiple Inheritance (Classes)	❌ No
Multiple Inheritance (Interfaces)	✅ Yes
**/

class OffEmployee : Person{
    double salary;
    string company = "";

    public string Company{
        get { return company; }
        set { company = value; }
    }

    int getSalary(){
        return (int)salary;
    }

    int getSalary(int bonus){
        return (int)salary + bonus;
    }
    
    //override: Replaces the parent implementation.
    public override string CalculateBirthYear(){
        if (DateTime.Now.Year - age > 21){
            return "Eligible for job application"; // Valid age
        }
        else{
            return " NOT eligible for job"; // Invalid age
        }
    }
}

/**
Polymorphism in C# has two main types:

1. Compile-Time Polymorphism: Same method name, Different parameters.
Also called:
Method Overloading
Static Polymorphism

Rule:
1. Methods must have the same name
2. Methods must have different parameter lists (different number of parameters or different types of parameters)
3. Methods can have different return types, but return type alone is not sufficient to distinguish overloaded methods.
4. Overloaded methods can have different access modifiers (public, private, etc.) and can be static or instance methods.

2. Run-Time Polymorphism: Compiler decides which method to call.
Also called:
Method Overriding
Dynamic Polymorphism

Rule:
1. The method in the base class must be marked with the 'virtual' keyword.
2. The method in the derived class must use the 'override' keyword.
3. The method signatures (name and parameters) must be the same in both base and derived classes.
4. The return type must be the same or covariant (derived type) in the overridden method.

Note:
COnstructors cannot be overridden, but they can be overloaded. 
They do not have return types, so they cannot be distinguished by return type alone and are called only when objects are created. 
They cannot be marked as virtual or override as they are not inherited like other methods.
**/