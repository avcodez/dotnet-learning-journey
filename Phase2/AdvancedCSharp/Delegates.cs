delegate void Operation();
delegate void NotificationHandler();

class Delegates
{
    // Delegate is a type that can store a reference to a method.
    // Delegates allow a method to receive behavior from outside instead of hardcoding it.
    //Store any method that returns void and takes no parameters

    public static void RunHardcoded(string val)
    {
        if (val == "Hello")
            SayHello();
        else if (val == "Bye")
            SayBye();
    }

    static void SayHello()
    {
        Console.WriteLine("Hello");
    }

    static void SayBye()
    {
        Console.WriteLine("Bye");
    }

    public static void SaveFile()
    {
        Console.WriteLine("File saved");
    }

    public static void SendEmail()
    {
        Console.WriteLine("Email sent");
    }

    public static void WriteAuditLog()
    {
        Console.WriteLine("Audit log written");
    }

    //Custom Delegate
    public static void ExecuteCustom(Operation method)
    {
        Console.WriteLine("\nBefore method");
        method();
        Console.WriteLine("After method");
    }

    //Built in Delegate
    //Action act = SayHello;
    //act();
    //A custom delegate and Action work the same way.
    //The only difference is who defined the delegate type: you (delegate void MyDelegate()) or Microsoft (Action).
    public static void Execute(Action method)
    {
        Console.WriteLine("\nBefore method");
        method();
        Console.WriteLine("After method");
    }

    //*********Multi Cast Delegate*********//

    public static void ExecuteNotification()
    {
        NotificationHandler notification = SendEmail;
        notification += SaveFile;
        notification += WriteAuditLog;

        Console.WriteLine("\nFirst Execution of multicast");
        notification();

        //notification -= SaveFile();

        //Above will result in error Cannot implicitly convert type 'void' to 'NotificationHandler'
        //Notice the (). SaveFile() means: Execute the method right now.
        // Since SaveFile() returns void, C# sees: notification -= void;
        //Cannot implicitly convert type 'void' to 'Notification'

        notification -= SaveFile;
        //warning in here: Possible null reference assignment. Thus on notification(); we can get Dereference of a possibly null reference.

        Console.WriteLine("\nSecond Execution of multicast after removing saveFile");
        notification();

        //if delegate has no methods left, then notification == null
        //And, if you then do: notification(); you would get a NullReferenceException.
        //Thus, the recommended way Use the null-conditional operator: notification?.Invoke();
        //notification?.Invoke(); will give no warning

        // notification(); and notification.Invoke(); these two are equivalent
        // But only Invoke() can be combined with ?.: like notification?.Invoke();
        // You cannot write: notification?();   // ❌ Invalid syntax

        notification += WriteAuditLog;
        Console.WriteLine("\nThird Execution of multicast after adding duplicate Auditlog");
        notification();
    }
}
