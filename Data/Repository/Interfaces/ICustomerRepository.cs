using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<int> AddAsync(CustomerEntity customer);
        public Task<List<CustomerEntity>> GetAllAsync();
        public Task<int> UpdateAsync(CustomerEntity customer);
        public Task<int> DeleteAsync(int id);
    }
}
