using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSale.Responses;
using System.Collections.Generic;

namespace PizzaTime.Core.v2.PointOfSaleMachine.Requests
{
    public class AddOrUpdateCustomerRequest : IPointOfSaleRequest<AddOrUpdateCustomerResponse>
    {
        public Customer Customer { get; set; }
        public string Remarks { get; set; }
    }

    public class AddOrUpdateCustomerRequestHandler : IPointOfSaleRequestHandler<AddOrUpdateCustomerRequest, AddOrUpdateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly Dictionary<string, string> _notes;

        public AddOrUpdateCustomerRequestHandler(ICustomerRepository customerRepo, Dictionary<string, string> notes)
        {
            _customerRepository = customerRepo;
            _notes = notes;
        }

        public AddOrUpdateCustomerResponse Handle(AddOrUpdateCustomerRequest request)
        {
            bool success = false;

            if (!string.IsNullOrEmpty(request.Customer.PhoneNumber)
                && !string.IsNullOrEmpty(request.Customer.FirstName)
                && !string.IsNullOrEmpty(request.Customer.LastName))
            {
                var customer = _customerRepository.GetById(request.Customer.Id);
                if (customer != null)
                {
                    _customerRepository.Remove(customer);
                }

                _customerRepository.Add(request.Customer);
                _notes[request.Customer.Id.ToString()] = request.Remarks;

                success = true;
            }

            return new AddOrUpdateCustomerResponse(success)
            {
                Customer = request.Customer
            };
        }
    }
}