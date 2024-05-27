using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Reports.Domain.Models;

namespace Go2Climb.API.Reports.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<IEnumerable<Report>> ListByServiceId(int serviceId);
        Task<IEnumerable<Report>> ListByCustomerId(int customerId);
        Task<Report> FindByIdAsync(int id);
        Task AddAsync(Report report);
        void Remove(Report report);
    }
}