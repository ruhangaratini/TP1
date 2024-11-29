namespace SalesSystem.model {
    internal class SaleItem {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public SaleItem(Product product, int quantity) {
            this.Product = product;
            this.Quantity = quantity;
        }

        public override string ToString() {
            return $"{this.Product} - QTD: ${this.Quantity}";
        }
    }
}
