using SalesSystem.model;

namespace SalesSystem.repository {
    internal class SaleRepository : DAO<Sale> {
        private static SaleRepository? instance;

        private SaleRepository() {}

        public static SaleRepository GetInstance() {
            if(SaleRepository.instance == null)
                SaleRepository.instance = new SaleRepository();

            return SaleRepository.instance;
        }

        public bool CustomerHasSale(Customer customer) {
            foreach (Sale sale in this.GetAll()) {
                if(sale.Customer == customer)
                    return true;
            }

            return false;
        }

        public bool ProductWasSold(Product product) {
            foreach (Sale sale in this.GetAll()) {
                foreach(SaleItem saleItem in sale.GetItems()) {
                    if (saleItem.Product == product) 
                        return true;
                }
            }

            return false;
        }
    }
}
