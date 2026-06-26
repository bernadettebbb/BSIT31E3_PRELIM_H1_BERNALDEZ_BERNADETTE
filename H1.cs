using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> studentIds = new List<int>();
    static List<string> studentNames = new List<string>();
    static List<double> grade1 = new List<double>();
    static List<double> grade2 = new List<double>();
    static List<double> grade3 = new List<double>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("=================================");
            Console.WriteLine("   STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student Grades");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Calculate Student Average");
            Console.WriteLine("7. Display Class Average");
            Console.WriteLine("8. Display Top Student");
            Console.WriteLine("9. Display Highest Grade");
            Console.WriteLine("10. Exit");
            Console.Write("\nEnter choice: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    ViewStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    UpdateGrades();
                    break;
                case 5:
                    DeleteStudent();
                    break;
                case 6:
                    StudentAverage();
                    break;
                case 7:
                    ClassAverage();
                    break;
                case 8:
                    TopStudent();
                    break;
                case 9:
                    HighestGrade();
                    break;
                case 10:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (choice != 10)
            {
                Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
            }
        }
        while (choice != 10);
    }

    static void AddStudent()
    {
        Console.Write("Student ID: ");
        studentIds.Add(int.Parse(Console.ReadLine()));

        Console.Write("Student Name: ");
        studentNames.Add(Console.ReadLine());

        Console.Write("Grade 1: ");
        grade1.Add(double.Parse(Console.ReadLine()));

        Console.Write("Grade 2: ");
        grade2.Add(double.Parse(Console.ReadLine()));

        Console.Write("Grade 3: ");
        grade3.Add(double.Parse(Console.ReadLine()));

        Console.WriteLine("\nStudent added successfully!");
    }

    static void ViewStudents()
    {
        if (studentIds.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("ID\tName\t\tAverage");

        for (int i = 0; i < studentIds.Count; i++)
        {
            double avg = (grade1[i] + grade2[i] + grade3[i]) / 3;
            Console.WriteLine($"{studentIds[i]}\t{studentNames[i]}\t\t{avg:F2}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        int index = studentIds.IndexOf(id);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        double avg = (grade1[index] + grade2[index] + grade3[index]) / 3;

        Console.WriteLine($"\nID: {studentIds[index]}");
        Console.WriteLine($"Name: {studentNames[index]}");
        Console.WriteLine($"Grades: {grade1[index]}, {grade2[index]}, {grade3[index]}");
        Console.WriteLine($"Average: {avg:F2}");
    }

    static void UpdateGrades()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        int index = studentIds.IndexOf(id);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("New Grade 1: ");
        grade1[index] = double.Parse(Console.ReadLine());

        Console.Write("New Grade 2: ");
        grade2[index] = double.Parse(Console.ReadLine());

        Console.Write("New Grade 3: ");
        grade3[index] = double.Parse(Console.ReadLine());

        Console.WriteLine("Grades updated successfully!");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        int index = studentIds.IndexOf(id);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        studentIds.RemoveAt(index);
        studentNames.RemoveAt(index);
        grade1.RemoveAt(index);
        grade2.RemoveAt(index);
        grade3.RemoveAt(index);

        Console.WriteLine("Student deleted successfully!");
    }

    static void StudentAverage()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        int index = studentIds.IndexOf(id);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        double avg = (grade1[index] + grade2[index] + grade3[index]) / 3;
        Console.WriteLine($"Average Grade: {avg:F2}");
    }

    static void ClassAverage()
    {
        if (studentIds.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double total = 0;

        for (int i = 0; i < studentIds.Count; i++)
            total += (grade1[i] + grade2[i] + grade3[i]) / 3;

        Console.WriteLine($"Class Average: {total / studentIds.Count:F2}");
    }

    static void TopStudent()
    {
        if (studentIds.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        int topIndex = 0;
        double highestAverage = (grade1[0] + grade2[0] + grade3[0]) / 3;

        for (int i = 1; i < studentIds.Count; i++)
        {
            double avg = (grade1[i] + grade2[i] + grade3[i]) / 3;

            if (avg > highestAverage)
            {
                highestAverage = avg;
                topIndex = i;
            }
        }

        Console.WriteLine($"Top Student: {studentNames[topIndex]}");
        Console.WriteLine($"Average: {highestAverage:F2}");
    }

    static void HighestGrade()
    {
        if (studentIds.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double highest = grade1[0];
        string student = studentNames[0];

        for (int i = 0; i < studentIds.Count; i++)
        {
            if (grade1[i] > highest)
            {
                highest = grade1[i];
                student = studentNames[i];
            }

            if (grade2[i] > highest)
            {
                highest = grade2[i];
                student = studentNames[i];
            }

            if (grade3[i] > highest)
            {
                highest = grade3[i];
                student = studentNames[i];
            }
        }

        Console.WriteLine($"Highest Grade: {highest}");
        Console.WriteLine($"Student: {student}");
    }
}