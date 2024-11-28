namespace SalesSystem.model {
    internal class Product {
        public int Code { get; set; }
        public String Mark { get; set; }
        public String Model { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }

        public Product(int code, String mark, String model, String description, double price) {
            this.Code = code;
            this.Mark = mark;
            this.Model = model;
            this.Description = description;
            this.Price = price;
        }

    }
}
