using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select storage format: 1 - JSON, 2 - XML");
        string choice = Console.ReadLine();

        string filePath;
        dynamic service;

        if (choice == "1")
        {
            filePath = "appointments.json";
            service = new JSONService(filePath);
        }
        else if (choice == "2")
        {
            filePath = "appointments.xml";
            service = new XMLService(filePath);
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting...");
            return;
        }

        List<Appointment> appointments = service.Load();
        Console.WriteLine("Current Appointments:");
        appointments.ForEach(a => Console.WriteLine(a));

        Console.WriteLine("\nAdd a new appointment:");
        
        string doctor = GetValidName("Doctor");
        string patient = GetValidName("Patient");
        DateTime date = GetValidDate();

        appointments.Add(new Appointment { Doctor = doctor, Patient = patient, Date = date });
        service.Save(appointments);

        Console.WriteLine("Appointment saved successfully.");
    }

    static string GetValidName(string fieldName)
    {
        while (true)
        {
            Console.Write($"{fieldName}: ");
            string input = Console.ReadLine();

            if (IsValidName(input))
                return input;

            Console.WriteLine($"Invalid {fieldName}. Please enter a valid name (only letters and spaces).");
        }
    }

    static bool IsValidName(string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[A-Za-z\s]+$");
    }

    // Метод для валідації дати
    static DateTime GetValidDate()
    {
        while (true)
        {
            Console.Write("Date (yyyy-mm-dd): ");
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime date) && date >= DateTime.Today)
                return date;

            Console.WriteLine("Invalid date. Please enter a valid future or current date (yyyy-mm-dd).");
        }
    }
}
