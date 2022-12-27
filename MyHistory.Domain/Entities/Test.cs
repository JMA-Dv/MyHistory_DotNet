namespace MyHistory.Domain.Entities
{
    public class Test:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;

        public int IdAppointment { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
