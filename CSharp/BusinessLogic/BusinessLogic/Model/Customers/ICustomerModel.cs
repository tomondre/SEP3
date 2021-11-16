using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Customers
{
    public interface ICustomerModel
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}