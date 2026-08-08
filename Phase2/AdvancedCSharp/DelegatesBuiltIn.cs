delegate void ExeCustom();

//Custom without paramter and void return type
delegate void ExeCustomWithParameter(string name);

//Custom with paramter and void return type

//Declared custom delegate
class DelegatesBuiltIn
{
    public static void SaveFile()
    {
        Console.WriteLine("File saved.");
    }

    public static void SaveFile(string str)
    {
        Console.WriteLine($"File saved by {str}");
    }

    public static void ExecuteCustom(ExeCustom method)
    {
        Console.WriteLine("\nBefore custom delegate method");
        method();
        Console.WriteLine("After custom delegate method");
    }

    public static void ExecuteBuiltIn(Action method)
    {
        Console.WriteLine("\nBefore Built-In delegate method without delegate declaration");
        method();
        Console.WriteLine("After Built-In delegate method");
    }

    public static void ExecuteCustomWithParamter(ExeCustomWithParameter method, string name)
    {
        Console.WriteLine("\nBefore custom delegate with parameter");
        method(name);
        Console.WriteLine("After custom delegate method");
    }

    //Built in Actin<T>
    public static void ExecuteBuiltInWithParameter(Action<string> method, string name)
    {
        Console.WriteLine("\nBefore Built-In delegate method with paramter");
        method(name);
        Console.WriteLine("After Built-In delegate method");
    }
}
