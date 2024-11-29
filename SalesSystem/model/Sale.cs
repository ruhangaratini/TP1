namespace SalesSystem.model {
    internal class Sale : IEntity {
        public int Code { get; private set; }
        public Customer Customer { get; set; }
        private List<SaleItem> Items;

        public Sale(Customer customer) {
            this.Customer = customer;
            this.Items = [];
        }

        public void AddProduct(Product product) {
            SaleItem? item = this.Items.Find(x => x.Product.Code == product.Code);

            if (item != null) {
                item.Quantity++;
                return;
            }

            this.Items.Add(new SaleItem(product, 1));
        }

        public SaleItem[] GetItems() {
            return this.Items.ToArray();
        }

        public double GetTotalValue() {
            double total = 0;
            foreach (SaleItem item in this.Items)
                total += item.Product.Price * item.Quantity;

            return total;
        }

        public int GetCode() {
            return this.Code;
        }

        public void SetCode(int id) {
            this.Code = id;
        }

        public override String ToString() {
            return $"{this.Code} - R${this.GetTotalValue()}";
        }
    }
}
