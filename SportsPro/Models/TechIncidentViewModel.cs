namespace SportsPro.Models
{
    public class TechIncidentViewModel
    {
        public int Id { get; set; }

        public List<TechnicianModel> Technicians { get; set; } = new List<TechnicianModel>();
    }
}
