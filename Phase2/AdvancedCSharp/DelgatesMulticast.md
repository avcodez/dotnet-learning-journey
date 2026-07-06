Topics Covered:
✔ What problem do delegates solve?
✔ Why are delegates better than if/switch for selecting behavior?
✔ How do you create and use a custom delegate?
✔ What is a method reference?
✔ What is the difference between SaveFile and SaveFile()?
✔ What is a multicast delegate?
✔ How do += and -= work?
✔ Can delegates contain duplicate methods?
✔ What happens if one multicast delegate method throws an exception?
✔ How do you ensure all subscribed methods execute?
✔ How do multicast delegates relate to events?

You created a delegate: delegate void Operation(); and assigned one method to it.

Operation op = SayHello;
op();

Memory representation (conceptually):
Operation
     │
     ▼
SayHello()

Output: Hello
A delegate is currently storing one method reference.
---------------------------------------------------------------------------------
Suppose after a user registers, your application needs to do three things.

User Registered
       │
       ├── Send Welcome Email
       ├── Save Audit Log
       └── Notify Admin

Without delegates, you might write:
void RegisterUser()
{
    SaveUser();
    SendWelcomeEmail();
    SaveAuditLog();
    NotifyAdmin();
}
Works.
But Management says: Also send an SMS. Now you modify RegisterUser() Again.
Next month... Give reward points. Modify again.
Not very extensible.

What if a delegate could hold multiple methods Like this?

Operation
     │
     ├──► SendEmail()
     ├──► SaveAuditLog()
     └──► NotifyAdmin()

Then one call operation(); would execute

SendEmail()
↓
SaveAuditLog()
↓
NotifyAdmin()

This is called a Multicast Delegate.

A multicast delegate is a delegate that stores references to multiple methods and invokes them one by one in the order they were added.

How do we create one?

1) First create a delegate. delegate void Operation();

2) Methods:
    public static void SendEmail() { }
    public static void SaveLog() { }
    public static void NotifyAdmin() { }

3) Instead of Operation op = SendEmail; we add more methods.

    Operation op = SendEmail;
    op += SaveLog;
    op += NotifyAdmin;

    += means adds another method to the delegate's invocation list.

4) Invocation: Now call op();

    Output:
    Email Sent
    Log Saved
    Admin Notified

    One delegate. Three methods.

5) Removing methods: You can remove a method.
    op -= SaveLog;
    Now the list becomes

    Operation
    ↓
    SendEmail()
    ↓
    NotifyAdmin()

    Output:
    Email Sent
    Admin Notified

    Note that id there are duplicate entries then -= will remove one occurrence per operation and not all the duplicate entries.

6) Adding the same method twice:
    Operation op = SendEmail;
    op += SendEmail;
    op();

    Output:
    Email Sent
    Email Sent

    Delegates allow duplicates.

But order matters. Execution happens in the order methods were added.

Method Reference vs Method Invocation

SaveFile      -> Method reference (delegate stores this)
SaveFile()    -> Method invocation (method executes immediately)

Correct:
Operation op = SaveFile;

Incorrect:
Operation op = SaveFile();   // Error because SaveFile() returns void


-----------------------------------------------------------------------------
Real world Scenario: Why is this useful?

Suppose you're building an e-commerce application. After an order is placed:

Instead of writing:
    SendEmail();
    UpdateInventory();
    GenerateInvoice();
    RewardCustomer();
    NotifyWarehouse();

You could build an invocation list:

    OrderPlacedDelegate
    ↓
    SendEmail()
    ↓
    UpdateInventory()
    ↓
    GenerateInvoice()
    ↓
    RewardCustomer()
    ↓
    NotifyWarehouse()

Then simply write orderPlaced(); Very flexible.
-------------------------------------------------------------------
Interview Question:

1) What is a Multicast Delegate?
    A delegate that can reference multiple methods and invoke them sequentially.

2) What will happen if one method in the multicast delegate throws an exception before the remaining methods are executed?

    By default, execution stops at the method that throws the exception. The exception propagates to the caller, and the remaining methods in the invocation list are not executed. If you need all methods to run regardless of failures, you can iterate through the delegate's invocation list (GetInvocationList()) and invoke each method inside its own try-catch block.

    Suppose you have:
    Notification notification = SendEmail;
    notification += SaveFile;
    notification += WriteAuditLog;

    And SaveFile throws an exception:
    public static void SaveFile()
    {
        Console.WriteLine("Saving file...");
        throw new Exception("Disk full!");
    }
    Now invoke:
    notification();

    Execution flow:
    notification()
    ↓
    SendEmail()      ✅ Executes successfully
    ↓
    SaveFile()       ❌ Throws Exception
    ↓
    WriteAuditLog()  ❌ Never executes

    Output:
    Email sent
    Saving file...
    Unhandled exception: Disk full!

    WriteAuditLog() is never called because the exception immediately breaks the invocation chain.

    Why?
    Internally, a multicast delegate behaves conceptually like this:
    foreach (var method in invocationList)
    {
        method();   // If this throws, the loop stops immediately.
    }
    If one iteration throws an exception, the loop exits unless the exception is caught.

3) How can you ensure all methods in a multicast delegate execute even if one throws an exception?

    Instead of invoking the multicast delegate directly, use GetInvocationList() to retrieve each subscribed delegate and invoke them individually inside a try-catch block. This isolates exceptions so one failing method doesn't stop the remaining methods from executing.
    This is the standard approach you'll see when reliable notification of all subscribers is required.

    To invoke each method individually and handle exceptions is recommended when every method must run**:
    foreach (Delegate d in notification.GetInvocationList())
    {
        try { d.DynamicInvoke(); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    or If you know delegate type then:
    foreach (Notification handler in notification.GetInvocationList())
    {
        try { handler();}
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    Now even if one method fails:
    Email sent
    Saving file...
    Disk full!
    Audit log written

    The remaining methods still execute.

    Why GetInvocationList()?
    A multicast delegate internally stores a list of methods.

    Notification
    ↓
    SendEmail()
    ↓
    SaveFile()
    ↓
    WriteAuditLog()

    GetInvocationList() returns that list, allowing you to invoke each method one by one.

4) Can any delegate be multicast?

    Any delegate can be multicast.

    However, delegates returning void are the most common because every subscribed method can execute without needing to combine return values.

    Delegates with return values can also be multicast, but only the return value of the LAST method is returned, making them less useful for multicast scenarios.
    
    This is a classic interview question.
    Example:
    delegate int Calculator();

    If three methods return:
    10
    20
    30

    The delegate invocation returns: 30
    because that's the last method executed.

--------------------------------------------------------------------
Events in C# are built on multicast delegates. Every event can have multiple subscribers.
Those subscribers are stored in the delegate's invocation list.