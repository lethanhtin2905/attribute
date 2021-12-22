using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// AttributeUsage specifies the usage
// of InformationAttribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor |
						AttributeTargets.Method, AllowMultiple = true)]

// InformationAttribute is a custom attribute class
// that is derived from Attribute class
class InformationAttribute : Attribute
{
	public string InformationString { get; set; }
}

// InformationAttribute is used in student class
[Information(InformationString = "Class")]
public class student
{

	private int rollno;
	private string name;

	[Information(InformationString = "Constructor")]
	public student(int rollno, string name)
	{
		this.rollno = rollno;
		this.name = name;
	}

	[Information(InformationString = "Method")]
	public void display()
	{
		Console.WriteLine("Roll Number: {0}", rollno);
		Console.WriteLine("Name: {0}", name);
	}
}

[AttributeUsage(
   AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]

public class DeBugInfo : System.Attribute
{
    private int bugNo;
    private string developer;
    private string lastReview;
    public string message;

    public DeBugInfo(int bg, string dev, string d)
    {
        this.bugNo = bg;
        this.developer = dev;
        this.lastReview = d;
    }
    public int BugNo
    {
        get
        {
            return bugNo;
        }
    }
    public string Developer
    {
        get
        {
            return developer;
        }
    }
    public string LastReview
    {
        get
        {
            return lastReview;
        }
    }
    public string Message
    {
        get
        {
            return message;
        }
        set
        {
            message = value;
        }
    }
}

[DeBugInfo(45, "Nguyễn Huy", "03/09/2017", Message = "Kiểu trả về không hợp lệ")]
[DeBugInfo(49, "Hà Minh", "09/11/2017", Message = "Biến chưa được sử dụng")]
class Rectangle
{
    //các biến thành viên
    protected double dai;
    protected double rong;
    public Rectangle(double d, double r)
    {
        dai = d;
        rong = r;
    }
    [DeBugInfo(55, "Nguyễn Huy", "03/09/2017", Message = "Kiểu trả về không hợp lệ")]

    public double tinhS()
    {
        return dai * rong;
    }
    [DeBugInfo(56, "Hà Minh", "09/11/2017")]

    public void Display()
    {
        Console.WriteLine("Chiều dài: {0}", dai);
        Console.WriteLine("Chiều rộng: {0}", rong);
        Console.WriteLine("Diện tích: {0}", tinhS());
    }
}

namespace attribute
{
    class Program
    {
        static void Main(string[] args)
        {
			student s = new student(1001, "Lily Adams");
			s.display();

            Rectangle r = new Rectangle(3, 5);
            Console.WriteLine(r.tinhS());

			Console.ReadKey();
		}
    }
}
