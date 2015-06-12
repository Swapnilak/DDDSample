using System.Linq;
using Domain.Infrastructure;
using Domain.Models;

namespace Domain.Specifications
{
    public class DuplicateCustomerName: IDuplicateCustomerName
    {
        readonly IRepository _repository;


        public DuplicateCustomerName(IRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Customer entity)
        {
            // customer must have a unique email address
            var anyCustomer = _repository.Project<Customer, bool>(customers => customers.Any(x => x.FirstName == entity.FirstName));
            return anyCustomer;
        }
    }

    public interface IDuplicateCustomerName : ISpecification<Customer>
    {
    }
}
