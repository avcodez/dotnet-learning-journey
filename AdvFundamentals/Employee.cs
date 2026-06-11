class Employee
{
    public string Name { get; }
    public int Age { get; }

    //Private constrctor is used in singleton pattern to prevent external instantiation.
    //Protected constructor is used in inheritance to allow only derived classes to instantiate.
    //Internal constructor is used to restrict instantiation to the same assembly.
    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
