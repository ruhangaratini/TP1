namespace SalesSystem.model {
    internal class Product : IEntity {
        public int Code { get; private set; }
        public String Mark { get; set; }
        public String Model { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }

        public Product(String mark, String model, String description, double price) {
            this.Mark = mark;
            this.Model = model;
            this.Description = description;
            this.Price = price;
        }

        public int GetCode() {
            return this.Code;
        }

        public void SetCode(int id) {
            this.Code = id;
        }

        public override String ToString() {
            return $"{this.Code} - {this.Model} {this.Mark} R${this.Price:#,##}";
        }
    }
}
