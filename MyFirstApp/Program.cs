Console.WriteLine("Hello, World!");
int number = 42;
Console.WriteLine("The number is: " + number);
string name = "Ayesha";
Console.WriteLine("My name is: " + name);

string[] names1  = new string [3]{ "Alice", "Bob", "Charlie" };
foreach (string i in names1){
    Console.WriteLine(i);
}

//Even if new is not written, compiler will understand that it is an array and will create an array of 3 strings. 
// This is called array initializer syntax.
string[] names2 = { "Apple", "Banana", "Cherry" };

foreach (string i in names2)
{
    Console.WriteLine(i);
}

//Multiplication table of 5

int ph = 5;
for(int i=1; i<=10; i++){
    Console.WriteLine(ph*i);
}

//Arrays
int[]numbers = { 45,16,15};

// C# does not allow partial initialization when using an initializer list. Either:
// Specify all 5 values, or
// Create the array and assign values later.
//int[]multi = new int [5] { 1,2,3};
int[]multi = new int [5] { 1,2,3,4,5};

//2D aaray
int[,] matrix = new int[2,3] { {1,2,3}, {4,5,6} };

for (int i=0;  i<3; i++){
    for (int j=0; j<3;j++){
        Console.WriteLine("\n" + numbers[i]*multi[j]);
    }
}

static void greet(string name){
    Console.WriteLine("Hello, " + name + "!");
}

greet("Ayeshaoio");