using SalesSystem.model;

namespace SalesSystem.repository {
    internal class CustomerRepository : DAO<Customer> {
        private static CustomerRepository? instance;

        private CustomerRepository() { }

        public static CustomerRepository GetInstance() {
            if (CustomerRepository.instance == null)
                CustomerRepository.instance = new CustomerRepository();

            return CustomerRepository.instance;
        }
    }
}
