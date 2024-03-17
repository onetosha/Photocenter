using Microsoft.EntityFrameworkCore;
using Photocenter.DAL.Interfaces;
using Photocenter.Helpers;
using Photocenter.Models.Entities;

namespace Photocenter.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ServiceRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<bool> Create(Service model)
        {
            await _dbContext.Services.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Service model)
        {
            _dbContext.Services.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Service> Get(int id)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Service>> GetAll()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<Service> Update(Service model)
        {
            _dbContext.Services.Update(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
