/** 
#Code:
class Employee {
    string name;
    int age;
}

Employee e1 = new Employee();
//e1 is a reference pointing to that object.
e1.name = "Alice";

#Above code throws error: CS8803 - Top-level statements must precede namespace and type declarations.

#Reason:
Top-Level Statements (C# 9 / .NET 6+):
Top-Level Statements allow executable code to be written directly in Program.cs without explicitly creating a Program class or Main() method.
The compiler automatically generates the Program class and Main() method behind the scenes.Before C# 9, every program required a Main() method:

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello");
    }
}

Now you can write: Console.WriteLine("Hello"); and the compiler automatically generates the Program class and Main() method behind the scenes.

Rule:
When using top-level statements, the order must be:

1. Using statements
2. Top-level code
3. Class/Interface/Enum declarations

Valid:
Employee e1 = new Employee();

class Employee { }

Top-level code comes before class declaration.

Invalid
class Employee { }

Employee e1 = new Employee();

Reason: The compiler expects - 

Using statements
↓
Top-level code
↓
Type declarations (class/interface/enum)

but found:

Type declaration
↓
Top-level code

which violates the top-level statement rule.
**/

// Employee e1 = new Employee();
// //e1 is a reference pointing to that object.
// e1.name = "Alice";
// e1.age = 30;
// Console.WriteLine(e1.name);
// Console.WriteLine(e1.age);

/**
Warning :  
Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

Reason :
This warning appeared because Nullable Reference Types were introduced in C# 8 to reduce NullReferenceExceptions, one of the most common runtime errors in .NET applications

Fix 1: Initialize the fields in the constructor: public string name = "";
Fix 2: Make the fields nullable: public string? name;
Fix 3: Use the 'required' modifier (C# 11+): public required string name;
Fix 4: Use constructor to set values: public Employee() { name = ""; }

Why int can't be null or does not get warning?
int is a value type and cannot contain null. Its default value is 0, which is a valid int value. Therefore, the compiler does not issue a warning because the field is initialized with a valid default value.
string is a reference type and its default value is null. 

With Nullable Reference Types enabled (C# 8+), a declaration like: string name; means "name should never be null".
When an Employee object is created, name is initially null, so the compiler warns that the non-nullable contract may be violated.
Thus,

| Declaration         | Category                      | Default Value | Can Be Null?     | Notes                              |
| ------------------- | ----------------------------- | ------------- | ---------------- | ---------------------------------- |
| `int age`           | Value Type                    | `0`           | ❌ No             | Must always contain a value        |
| `int? age`          | Nullable Value Type           | `null`        | ✅ Yes            | Shorthand for `Nullable<int>`      |
| `Nullable<int> age` | Nullable Value Type           | `null`        | ✅ Yes            | Equivalent to `int?`               |
| `string name`       | Reference Type (Non-Nullable) | `null`        | ✅ Physically yes | Compiler warns if it may be `null` |
| `string? name`      | Nullable Reference Type       | `null`        | ✅ Yes            | Explicitly allows `null`           |


int? age = null; or Nullable<int> age = null; both are equivalent and allow age to be null, while int age = null; is invalid because int cannot be null.
**/

class Employee {
    public string name { get; set; }
    public int age;
}