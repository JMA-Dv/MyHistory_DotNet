namespace MyHistory.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public int IdSpecialist { get; set; }
        public Specialist? Specialist { get; set; }
        public ICollection<Test>? Tests { get; set; }
        public ICollection<Medication>? Medications { get; set; }

        public Guid IdUser { get; set; }
        public User User { get; set; }
    }
}
