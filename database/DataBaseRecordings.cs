/*
This is the first sample edition guide
Make your own cutom data base
Test more whenever u can ! 
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentDatabase
{
    private readonly List<Student> students = new List<Student>();

    public StudentDatabase()
    {
        // Initial records
        AddStudent(new Student(1001, "Alice", 20, 92.5, true));
        AddStudent(new Student(1002, "Brian", 21, 87.0, true));
        AddStudent(new Student(1003, "Clara", 19, 95.8, false));
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public Student? FindById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public void DisplayAll()
    {
        foreach (Student student in students)
        {
            DisplayStudent(student);
        }
    }

    public void DisplayStudent(Student student)
    {
        Console.WriteLine(
            $"ID: {student.Id} | " +
            $"Name: {student.Name} | " +
            $"Age: {student.Age} | " +
            $"GPA: {student.GPA:F1} | " +
            $"Enrolled: {student.IsEnrolled}");
    }

    public void DisplayField(string fieldName)
    {
        foreach (Student student in students)
        {
            switch (fieldName.ToLower())
            {
                case "id":
                    Console.WriteLine(student.Id);
                    break;

                case "name":
                    Console.WriteLine(student.Name);
                    break;

                case "age":
                    Console.WriteLine(student.Age);
                    break;

                case "gpa":
                    Console.WriteLine(student.GPA);
                    break;

                case "enrolled":
                    Console.WriteLine(student.IsEnrolled);
                    break;

                default:
                    Console.WriteLine($"Unknown field: {fieldName}");
                    return;
            }
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }
    public bool IsEnrolled { get; set; }

    public Student(int id, string name, int age, double gpa, bool isEnrolled)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = gpa;
        IsEnrolled = isEnrolled;
    }
}

class DataBaseRecordings
{
    static void Main(string[] args)
    {
        StudentDatabase database = new StudentDatabase();

        Console.WriteLine("=== 1. ALL RECORDS ===");
        database.DisplayAll();

        Console.WriteLine("\n=== 2. NAMES ONLY ===");
        database.DisplayField("name");

        Console.WriteLine("\n=== 3. GPA ONLY ===");
        database.DisplayField("gpa");

        Console.WriteLine("\n=== 4. FIND ONE RECORD ===");

        Student? result = database.FindById(1002);

        if (result != null)
        {
            database.DisplayStudent(result);
        }
        else
        {
            Console.WriteLine("Record not found.");
        }

        Console.WriteLine("\n=== 5. ADD A NEW RECORD ===");

        database.AddStudent(new Student(1004, "David", 22, 89.4, true));

        database.DisplayAll();

        Console.WriteLine("\n=== 6. DISPLAY THE NEW RECORD'S NAME ===");

        Student? newStudent = database.FindById(1004);

        if (newStudent != null)
        {
            Console.WriteLine(newStudent.Name);
        }
    }
}


