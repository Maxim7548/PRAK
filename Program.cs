/*
using System;
using System.Collections.Generic;

interface IShape
{
    void Draw();
}

interface IColoredShape : IShape
{
    void SetColor(string color);
}

class Circle : IColoredShape
{
    private static int circleCount = 0;

    private int instanceNumber;

    public string Color { get; private set; } = "Без кольору";

    public Circle()
    {
        circleCount++;
        instanceNumber = circleCount;
    }

    // Реалізація Draw()
    public void Draw()
    {
        Console.WriteLine($"Коло {instanceNumber}. Колір: {Color}");
    }

    // Реалізація SetColor()
    public void SetColor(string color)
    {
        Color = color;
    }

    // Перевизначення ToString()
    public override string ToString()
    {
        return $"Коло {instanceNumber} (колір: {Color})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення об'єктів
        Circle redCircle = new Circle();
        redCircle.SetColor("Червоний");

        Circle blueCircle = new Circle();
        blueCircle.SetColor("Синій");

        Circle greenCircle = new Circle();
        greenCircle.SetColor("Зелений");

        // Створення списку IShape
        List<IShape> shapes = new List<IShape>
        {
            redCircle,
            blueCircle,
            greenCircle
        };

        Console.WriteLine("Список фігур (Draw):");
        foreach (var shape in shapes)
        {
            shape.Draw();
        }

        Console.WriteLine("\nОпис фігур (ToString):");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
}
*/

using System;
using System.Collections.Generic;

interface IReportable
{
    string GenerateReport();
}

// Базовий клас для всіх працівників.
class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    public virtual decimal CalculateBonus()
    {
        return 0m; 
    }

    // Перевизначення методу ToString()
    public override string ToString()
    {
        return $"{Name}, зарплата: {Salary:C}, бонус: {CalculateBonus():C}";
    }
}

    // Похідний клас
class Manager : Employee, IReportable
{
    public Manager(string name, decimal salary) : base(name, salary) { }

    // Перевизначення методу CalculateBonus().
    public override decimal CalculateBonus()
    {
        return Salary * 0.20m; 
    }

    // Реалізація методу IReportable.
    public string GenerateReport()
    {
        return $"\nЗвіт менеджера {Name}: зарплата {Salary:C}, бонус {CalculateBonus():C}";
    }
}

// Похідний клас Developer. Успадковує Employee.
class Developer : Employee
{
    public Developer(string name, decimal salary) : base(name, salary) { }

    // Перевизначення методу CalculateBonus()
    public override decimal CalculateBonus()
    {
        return Salary * 0.10m; 
    }
}

class Program2
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення списку працівників
        List<Employee> employees = new List<Employee>
        {
            new Manager("Олена", 50000),
            new Developer("Андрій", 40000),
            new Developer("Марія", 42000),
            new Manager("Ігор", 60000m)
        };

        Console.WriteLine("Працівники компанії:");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("\nЗвіти менеджерів ");
        foreach (var emp in employees)
        {
            if (emp is IReportable reportable)
            {
                Console.WriteLine(reportable.GenerateReport());
            }
        }
    }
}
