using Data.Contexts;
using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CustomerRepository(DataContext context) : ICustomerRepository
    {
        public async Task<int> AddAsync(CustomerEntity customer)
        {
            context.Customers.Add(customer);
            return await context.SaveChangesAsync();
        }

        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<int> UpdateAsync(CustomerEntity customer)
        {
            context.Attach(customer).State = EntityState.Modified;

            return await context.SaveChangesAsync();
        }


        public async Task<int> DeleteAsync(int id)
        {
            var customerentity = await context.Customers.FindAsync(id);
            if (customerentity != null)
            {
                context.Customers.Remove(customerentity);
                await context.SaveChangesAsync();
            }
            return 1;
        }
    }
}
