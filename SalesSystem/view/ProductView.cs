using SalesSystem.model;
using SalesSystem.repository;
using SalesSystem.util;

namespace SalesSystem.view {
    internal class ProductView {
        public static void ShowMenu() {
            ProductRepository repository = ProductRepository.GetInstance();
            String input = "";

            while (!input.Equals("5")) {
                Console.WriteLine("------- PRODUTOS -------");
                Console.WriteLine("1. Cadastrar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Remover");
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

        public static Product RegisterProduct() {
            Console.Write("Marca: ");
            String mark = Console.ReadLine() ?? "";

            Console.Write("Modelo: ");
            String model = Console.ReadLine() ?? "";

            Console.Write("Descricao: ");
            String description = Console.ReadLine() ?? "";

            double price = InputUtil.InputDouble("Preco: ");

            return new Product(mark, model, description, price);
        }

        public static void SearchProduct() {
            ProductRepository repository = ProductRepository.GetInstance();

            int code = InputUtil.InputInt("Codigo: ");

            Product? product = repository.GetByCode(code);

            if(product == null) {
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

            int code = InputUtil.InputInt("Codigo: ");

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
