namespace SalesSystem.model {
    internal class Customer : IEntity {
        public int Code { get; private set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Cpf { get; set; }

        public Customer(int code, String name, int age, String cpf) {
            this.Code = code;
            this.Name = name;
            this.Age = age;
            this.Cpf = cpf;
        }

        public int GetCode() {
            return this.Code;
        }

        public void SetCode(Func<int> generateID) {
            this.Code = generateID();
        }
    }
}
