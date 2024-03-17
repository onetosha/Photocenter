using Microsoft.EntityFrameworkCore;
using Photocenter.DAL.Interfaces;
using Photocenter.Helpers;
using Photocenter.Models.Entities;

namespace Photocenter.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ClientRepository(ApplicationDBContext dBContext) 
        {
            _dbContext = dBContext;
        }
        public async Task<bool> Create(Client entity)
        {
            await _dbContext.Clients.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Client entity)
        {
            _dbContext.Clients.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Client> Get(int id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> Update(Client entity)
        {
            _dbContext.Clients.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
