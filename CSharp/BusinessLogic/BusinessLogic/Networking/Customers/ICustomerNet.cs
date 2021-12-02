﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Customers
{
    public interface ICustomerNet
    {
        Task<User> CreateCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int customerId);
        Task<IList<Customer>> FindCustomerByNameAsync(string name);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> EditCustomerAsync(Customer customer);
    }
}