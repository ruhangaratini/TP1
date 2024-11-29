using SalesSystem.model;
using SalesSystem.repository;
using SalesSystem.util;

namespace SalesSystem.view {
    internal class SaleView {
        public static void ShowMenu() {
            ProductRepository repository = ProductRepository.GetInstance();
            String input = "";

            while (!input.Equals("5")) {
                Console.WriteLine("------- VENDAS -------");
                Console.WriteLine("1. Cadastrar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Total");
                Console.WriteLine("5. Sair");
                Console.WriteLine("------------------------");
                Console.Write("Opcao: ");

                input = Console.ReadLine() ?? "";
                Console.Clear();

                switch (input) {
                    case "1":
                        repository.Add(RegisterProduct());
                        break;
                    case "2":
                        SearchProduct();
                        break;
                    case "3":
                        ListAll();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                }

                if (!input.Equals("5"))
                    InterfaceUtil.PressEnterToContinue();

                Console.Clear();
            }
        }

        public static Sale? RegisterSale() {
            CustomerRepository customerRepository = CustomerRepository.GetInstance();
            ProductRepository productRepository = ProductRepository.GetInstance();

            Console.Write("Codigo cliente: ");
            Customer? customer = customerRepository.GetByCode(Convert.ToInt32(Console.ReadLine()));

            if (customer == null) {
                Console.WriteLine("Cliente nao encontrado");
                return null;
            }

            Sale sale = new Sale(customer);

            String input = "";

            while (!input.Equals("0")) {
                Console.Clear();

                ProductView.ListAll();

                Console.WriteLine("Codigo [0 para sair]:");
                input = Console.ReadLine() ?? "";

                if (input.Equals("0"))
                    break;

                Product? product = productRepository.GetByCode(Convert.ToInt32(input));

                if (product == null) {
                    Console.WriteLine("Produto nao encontrado!");
                    InterfaceUtil.PressEnterToContinue();
                    continue;
                }
            }

            Console.Write("Modelo: ");
            String model = Console.ReadLine() ?? "";

            Console.Write("Descricao: ");
            String description = Console.ReadLine() ?? "";

            Console.Write("Preco: ");
            double price = Convert.ToDouble(Console.ReadLine());

            return new Sale(customer);
        }

        public static void SearchProduct() {
            ProductRepository repository = ProductRepository.GetInstance();

            Console.Write("Codigo: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Product? product = repository.GetByCode(code);

            if (product == null) {
                Console.WriteLine("Produto nao encontrado");
                return;
            }

            Console.WriteLine(product);
        }

        public static void ListAll() {
            foreach (Product product in ProductRepository.GetInstance().GetAll())
                Console.WriteLine(product);
        }

        public static void RemoveProduct() {
            ProductRepository productRepository = ProductRepository.GetInstance();
            SaleRepository saleRepository = SaleRepository.GetInstance();

            Console.Write("Codigo: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Product? product = productRepository.GetByCode(code);

            if (product == null) {
                Console.WriteLine("Produto nao encontrado");
                return;
            }

            if (saleRepository.ProductWasSold(product)) {
                Console.WriteLine("O produto ja possui venda registrada");
                return;
            }

            productRepository.Remove(product);
            Console.WriteLine("Produto removido com sucesso");
        }
    }
}
