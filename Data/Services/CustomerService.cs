using Data.Entities;
using Data.Repository.Interfaces;
using Data.Services.Interfaces;

namespace Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        // Constructor to inject the DataContext
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }

        // Method to get all customers from the database
        public async Task<List<CustomerEntity>> GetAll()
        {
            // Use Entity Framework to fetch all customers from the Customers DbSet
            return await _customerRepository.GetAllAsync();
        }

        public async Task<int> Add(CustomerEntity customerEntity)
        {
            return await _customerRepository.AddAsync(customerEntity);
        }

        public async Task<int> Update(CustomerEntity customerEntity)
        {
            return await _customerRepository.UpdateAsync(customerEntity);
        }

        public async Task<int> Delete(int id)
        {
             return await _customerRepository.DeleteAsync(id);
        }
    }
}
