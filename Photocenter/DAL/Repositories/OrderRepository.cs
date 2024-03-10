using Microsoft.EntityFrameworkCore;
using Photocenter.DAL.Interfaces;
using Photocenter.Models.Entities;

namespace Photocenter.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<bool> Create(Order model)
        {
            await _dbContext.Orders.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Order model)
        {
            _dbContext.Orders.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Get(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> Update(Order model)
        {
            _dbContext.Orders.Update(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
