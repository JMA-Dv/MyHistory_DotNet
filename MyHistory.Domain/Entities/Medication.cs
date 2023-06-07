namespace MyHistory.Domain.Entities
{
    public class Medication:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Presentation { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicationAppointment>? MedicationAppointments { get; set; }
    }
}
