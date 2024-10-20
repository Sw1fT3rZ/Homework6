public class Appointment
{
    public string Doctor { get; set; }
    public string Patient { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Doctor: {Doctor}, Patient: {Patient}, Date: {Date}";
    }
}
