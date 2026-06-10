/**What is an Exception? An exception is a runtime error that breaks normal program flow.

Without exception handling, the program would crash when an error occurs.
With exception handling, you can catch and handle errors gracefully, allowing the program to continue running or exit cleanly.

try → catch → finally → throw

Try: Wraps code that may throw an exception.
Catch: Handles the exception if it occurs.
Finally: Code that always executes, regardless of whether an exception was thrown or caught.
throw: manually trigger an exception.

1) Specific Exception Handling: Catch specific exceptions to handle known error conditions.
2) Multiple Catch Blocks: Use multiple catch blocks to handle different types of exceptions separately.
3) Exception properties: Use properties like Message, StackTrace, and InnerException to get more information about the error.
4) Custom Exceptions: Create your own exception classes by inheriting from the base Exception class to represent specific error conditions in your application.
5) Rethrowing Exceptions: You can catch an exception, perform some logging or cleanup,
**/

try
{
    int a = 10;
    int b = 0;
    int result = a / b;
    int[] arr = new int[5];
    arr[7] = 10; // Index out of range
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Array index error: " + ex.Message);
    Console.WriteLine("Stack Trace: " + ex.StackTrace);
    Console.WriteLine("Inner Exception: " + ex.InnerException);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Math error: " + ex.Message);
    Console.WriteLine("Stack Trace: "+ ex.StackTrace);
    Console.WriteLine("Inner Exception: " + ex.InnerException);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    Console.WriteLine("Always executes");
}
//throw new Exception("Custom error message");