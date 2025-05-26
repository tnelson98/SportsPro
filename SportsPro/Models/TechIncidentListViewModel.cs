namespace SportsPro.Models
{
    public class TechIncidentListViewModel
    {
        public TechnicianModel Technician { get; set; } = new TechnicianModel();

        public List<IncidentModel> Incidents { get; set; } = new List<IncidentModel>();
    }
}
