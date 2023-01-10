namespace MyHistory.Domain.Entities
{
    public class Specialty:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int IdSpecialist { get; set; }
        public Specialist? Specialist { get; set; }
    }
}
