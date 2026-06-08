
//Required member 'Student.name' must be set in the object initializer or attribute constructor.

/**
Fields vs Properties
Fields: A field is a variable declared directly inside a class.

class Employee
{
    public int age;
}

Usage:

Employee e1 = new Employee();
e1.age = 30;
Can We Validate Values Using Fields? Yes, but validation must be performed manually before assigning the value.

if(inputAge >= 0)
{
    e1.age = inputAge;
}
Problem with Fields: The class cannot prevent invalid assignments from outside.

e1.age = -100; // Allowed

Any code can directly modify the field, making it difficult to enforce business rules.

Properties: A property provides controlled access to data using get and set accessors.

class Employee
{
    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if(value >= 0)
            {
                age = value;
            }
        }
    }
}

Usage:

Employee e1 = new Employee();

e1.Age = 30;    // Valid
e1.Age = -100;  // Rejected by setter
Advantage of Properties: Validation logic is centralized inside the class.

Instead of relying on every developer to validate values before assignment, the class itself ensures that only valid data is stored.
**/


class Student {
    public string name = "";
    public int age;
}
