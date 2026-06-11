/**What is Encapsulation? Encapsulation means hiding data and controlling access to it.

Simple definition: Keep data private and provide controlled access through methods or properties.

Interview Definition:
Encapsulation is the OOP principle of bundling data and behavior into a class while restricting direct access to internal data using access modifiers and controlled interfaces such as properties.

Problem Without Encapsulation:
class Employee
{
    public int age;
}

Employee e1 = new Employee();

e1.age = -100; // An employee cannot have a negative age.

Solution: Make Data Private
private int age; //'Employee.age' is inaccessible due to its protection level

Controlled Access Using Properties:
class Employee
{
    private int age;

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            if (value >= 0)
            {
                age = value;
            }
        }
    }
}

Auto-Implemented Properties:

If no validation is needed:
class Employee
{
    public string Name { get; set; } = "";
}

Compiler automatically creates a hidden private field.
Conceptually similar to:
private string name = "";

public string Name
{
    get { return name; }
    set { name = value; }
}

Benifits of Encapsulation:
1. Data Hiding: Internal state of the object is hidden from outside.
2. Controlled Access: Access to data can be controlled through methods or properties.
3. Improved Maintainability: Changes to internal implementation do not affect external code.
4. Increased Security: Prevents unauthorized access and modification of data.
5. Better Abstraction: Users interact with a simplified interface without needing to understand complex internals.
6. Easier Debugging: Encapsulation allows for easier identification and fixing of bugs since the internal state is protected and can only be modified through controlled methods.
7. Reusability: Encapsulated code can be reused across different parts of the application without worrying about unintended side effects, as the internal state is protected.
Encapsulation is a fundamental principle of object-oriented programming that promotes modularity, maintainability, and security by controlling access to an object's internal state and behavior.
**/

/**

Common Interview Question

Q: Why not make the field public and validate before assigning?

if(inputAge >= 0)
{
    employee.age = inputAge;
}

A: Because every developer must remember to validate every time. Someone will eventually forget.

With encapsulation:

employee.Age = inputAge;

The class itself guarantees the rule is enforced


Outside Code
      |
      v
  Public Property
      |
      v
 Validation Logic
      |
      v
 Private Field

 The field is private to prevent direct access and protect the data from invalid changes.

The property is public so other code can read or modify the data in a controlled way through get and set, where validation and business rules can be applied.
 **/
class BankAccount
{
    private decimal balance;

    //A field and a property cannot have the same name within the same class.
    // The common convention is to use _balance or balance for the private field and Balance for the public property.
    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
            {
                balance = value;
                //Assign private field only if the value is valid (non-negative)
            }
        }
    }
}
