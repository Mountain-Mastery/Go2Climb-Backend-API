using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Persistence.Repositories;
using Go2Climb.API.Reports.Domain.Models;
using Go2Climb.API.Reports.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Reports.Persistence
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Report>> ListAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<IEnumerable<Report>> ListByServiceId(int serviceId)
        {
            return await _context.Reports.Where(p => p.ServiceId == serviceId).Include(p => p.Customer).ToListAsync();
        }

        public async Task<IEnumerable<Report>> ListByCustomerId(int customerId)
        {
            return await _context.Reports.Where(p => p.CustomerId == customerId).Include(p => p.Customer).ToListAsync();
        }

        public async Task<Report> FindByIdAsync(int id)
        {
            return await _context.Reports
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Report report)
        {
            await _context.Reports.AddAsync(report);
        }

        public void Remove(Report report)
        {
            _context.Reports.Remove(report);
        }
    }
}