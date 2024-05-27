using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Reports.Domain.Models;
using Go2Climb.API.Reports.Domain.Services.Communication;

namespace Go2Climb.API.Reports.Domain.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<IEnumerable<Report>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<Report>> ListByCustomerIdAsync(int customerId);
        Task<ReportResponse> GetByIdAsync(int id);
        Task<ReportResponse> SaveAsync(Report report);
        Task<ReportResponse> DeleteAsync(int id);
    }
}