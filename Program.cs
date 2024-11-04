using Reflection_Basic;
using System.Reflection;

class Program
{
    static void Main()
    {
        LibraryClass libraryClass = new LibraryClass();
        Type type = libraryClass.GetType();

        Console.Write($"Found a class: {type.FullName} \n");

        //Methods
        MethodInfo[] methods = type.GetMethods();
        Console.WriteLine($"\nThe methods found from the {type.Name} are: \n");

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }

        //Properties
        PropertyInfo[] properties = type.GetProperties();
        Console.WriteLine($"\nThe properties found from the {type.Name} are: \n");

        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"\nInvoking method from the {type.Name} \n");
        //Invoke a method
        MethodInfo methodHi = type.GetMethod("SayHi");
        string data = methodHi.Invoke(libraryClass, null)?.ToString();

        Console.WriteLine(data);

        Console.Read();
    }
}