using Go2Climb.API.Resources;
using Go2Climb.API.Services.Resources;

namespace Go2Climb.API.Reports.Resources
{
    public class ReportResource
    {
        public int Id { get; set; }
        public int ServiceId { get; set; } 
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public ServiceResource Service { get; set; }
        public CustomerResource Customer { get; set; }
    }
}