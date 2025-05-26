namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        public string Filter { get; set; } = "all";

        public List<IncidentModel> Incidents { get; set; } = new List<IncidentModel>();
    }
}
