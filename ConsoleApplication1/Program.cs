using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Specifications;
using Moq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new AppContext("Database"))
            using (var repo = new Repository(context))
            {

                //With Mock
                //var duplicateCustomerEmail = new Mock<IDuplicateCustomerEmail>();
                //duplicateCustomerEmail.Setup(x => x.IsSatisfiedBy(It.IsAny<Customer>())).Returns(false);
                
                //var cust = new Customer(Guid.NewGuid(), "Swapnila", "Kadam", "abcd@mastercard.com", duplicateCustomerEmail.Object);
                //repo.Add(cust);

                //Without Mock
                //using AND Customer specification
                var duplicateCustomerEmail = new DuplicateCustomerEmail(repo);
                var duplicateCustomerName = new DuplicateCustomerName(repo);
                ISpecification<Customer> cust1 = duplicateCustomerEmail.And(duplicateCustomerName);

                var cust = new Customer(Guid.NewGuid(), "XYZ", "123", "a123@mastercard.com", cust1);
                repo.Add(cust);
            }
        }
    }
}
