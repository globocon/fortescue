using Microsoft.EntityFrameworkCore;
using FortescueWebApp.Models;


namespace FortescueWebApp.Repositories
{

    public interface IWorkOrderRepository
    {
        Task<IEnumerable<WorkOrder>> GetAllAsync();
        Task<WorkOrder> GetByIdAsync(int id);
        Task AddAsync(WorkOrder workOrder);
        Task UpdateAsync(WorkOrder workOrder);
        Task DeleteAsync(int id);
    }
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly AppDbContext _context;

        public WorkOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkOrder>> GetAllAsync()
        {
            return await _context.WorkOrders.OrderByDescending(w => w.Id).ToListAsync();
        }

        public async Task<WorkOrder> GetByIdAsync(int id)
        {
            return await _context.WorkOrders.FindAsync(id);
        }

        public async Task AddAsync(WorkOrder workOrder)
        {
            await _context.WorkOrders.AddAsync(workOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Update(workOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder != null)
            {
                _context.WorkOrders.Remove(workOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
