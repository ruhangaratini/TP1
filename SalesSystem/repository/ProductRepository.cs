using SalesSystem.model;

namespace SalesSystem.repository {
    internal class ProductRepository : DAO<Product> {
        private static ProductRepository? instance;

        private ProductRepository() { }

        public static ProductRepository GetInstance() {
            if (ProductRepository.instance == null)
                ProductRepository.instance = new ProductRepository();

            return ProductRepository.instance;
        }
    }
}
