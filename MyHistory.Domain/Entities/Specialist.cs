namespace MyHistory.Domain.Entities
{
    public class Specialist:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string License { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<Specialty>? Specialties { get; set; }
    }
}
