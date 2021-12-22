// C# program to display the custom attributes
#define DEBUG
using System;
using System.Reflection;
using System.Diagnostics;

// Defining a Custom attribute class
[AttributeUsage(AttributeTargets.All)]
class MyAttribute : Attribute
{
	// Private fields
	private string title;
	private string description;

	// Parameterised Constructor
	public MyAttribute(string t, string d)
	{
		title = t;
		description = d;
	}

	// Method to show the Fields of the NewAttribute using reflection
	public static void AttributeDisplay(Type classType)
	{
		Console.WriteLine("Methods of class {0}", classType.Name);

		// Array to store all methods of a class to which the attribute may be applied
		MethodInfo[] methods = classType.GetMethods();

		// for loop to read through all methods
		for (int i = 0; i < methods.GetLength(0); i++)
		{
			// Creating object array to receive method attributes returned by the GetCustomAttributes method
			object[] attributesArray = methods[i].GetCustomAttributes(true);

			// foreach loop to read through all attributes of the method
			foreach (Attribute item in attributesArray)
			{
				if (item is MyAttribute)
				{
					// Display the fields of the NewAttribute
					MyAttribute attributeObject = (MyAttribute)item;
					Console.WriteLine("{0} - {1}, {2} ", methods[i].Name,
					attributeObject.title, attributeObject.description);
				}
			}
		}
	}
}

// Class Student
class Student
{
	int id;
	string name;

	// Constructor
	public Student(int i, string s)
	{
		id = i;
		name = s;
	}

	// Applying the custom attribute MyAttribute to the getId method
	[MyAttribute("Accessor", "Gives value of Student Id")]
	public int getId()
	{
		return id;
	}

	// Applying the custom attribute MyAttribute to the getName method
	[MyAttribute("Accessor", "Gives value of Student Name")]
	public string getName()
	{
		return name;
	}
}


public class Myclass
{
	[Conditional("DEBUG")]
	public static void Message(string msg)
	{
		Console.WriteLine(msg);
	}
}

namespace attribute
{
	class Program
	{
		//Using Obsolete
		[Obsolete("Don't use OldMethod, use NewMethod instead", false)]
		static void OldMethod()
		{
			Console.WriteLine("It is the old method");
		}
		static void NewMethod()
		{
			Console.WriteLine("It is the new method");
		}

		//Using Conditional
		static void function1()
		{
			Myclass.Message("Conditional In Function 1.");
			function2();
		}
		static void function2()
		{
			Myclass.Message("Conditional In Function 2.");
		}

		// Main 
		static void Main(string[] args)
		{
			//Conditional attribue
			Myclass.Message("Conditional In Main function.");
			function1();
			Console.ReadKey();
			Console.WriteLine();

			//Obsolete attribute
			OldMethod();
			Console.ReadKey();
			Console.WriteLine();

			//Custom attribute
			MyAttribute.AttributeDisplay(typeof(Student));
			Console.ReadKey();
			Console.WriteLine();

			
		}
	}
}
