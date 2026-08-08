Console.WriteLine("Hello, World!");

Console.WriteLine("\nSignificance of Delegate: ");

//Without Delegate:
//Problem: Every time you want new behavior (SayGoodMorning, SayThanks, etc.), you must modify DoSomething().
Delegates.RunHardcoded("Bye");

//Custom delegate:
//Notice that ExecuteCustom() doesn't know which method it's calling.
//It simply says: "Give me a method, and I'll execute it." This is the power of delegates
Delegates.ExecuteCustom(Delegates.SaveFile);

//Built-in Delegate:
//Microsoft noticed everyone keeps writing delegates like this: delegate void PrintDelegate();
// Microsoft already provides common delegate types such as Action, Func, and Predicate.
Delegates.Execute(Delegates.SendEmail);

//If you want to overload the method names then Explicitly cast.
//Delegates.Execute((Operation)Delegates.SayHello);
//Delegates.Execute((Action)Delegates.SayHello);

Console.WriteLine("\nMulti Cast Delegate: ");
Delegates.ExecuteNotification();

//------------------------------------------------------------------------------------------
//Action method comparison with custom delefate with void return type
Console.WriteLine("\nAction, Func and Predicate: ");
DelegatesBuiltIn.ExecuteCustom(DelegatesBuiltIn.SaveFile);
DelegatesBuiltIn.ExecuteBuiltIn(DelegatesBuiltIn.SaveFile);

Console.WriteLine("\nAction<T>:");
DelegatesBuiltIn.ExecuteCustomWithParamter(DelegatesBuiltIn.SaveFile, "AV");
DelegatesBuiltIn.ExecuteBuiltInWithParameter(DelegatesBuiltIn.SaveFile, "VA");
