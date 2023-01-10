namespace MyHistory.Domain.Entities
{
    public class MedicationAppointment:BaseClass
    {
        public int Id { get; set; }
        public int IdMedication { get; set; }
        public Medication? Medication { get; set; }
        public int IdAppointment { get; set; }
        public Appointment? Appointment { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int DurationDays { get; set; }
        public string DoseDescription { get; set; } = string.Empty;
    }
}
