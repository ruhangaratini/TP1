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
    }
}
