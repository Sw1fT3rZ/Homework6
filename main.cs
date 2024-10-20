using System;
using System.Collections.Generic;

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
        Console.Write("Doctor: ");
        string doctor = Console.ReadLine();

        Console.Write("Patient: ");
        string patient = Console.ReadLine();

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        appointments.Add(new Appointment { Doctor = doctor, Patient = patient, Date = date });
        service.Save(appointments);

        Console.WriteLine("Appointment saved successfully.");
    }
}
