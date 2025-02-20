using Data.Entities;

namespace Data.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerEntity>> GetAll();
        public Task<int> Add(CustomerEntity customerEntity);
        public Task<int> Update(CustomerEntity customerEntity);
        public Task<int> Delete(int id);
    }
}
