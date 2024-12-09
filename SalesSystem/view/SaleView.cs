using SalesSystem.model;
using SalesSystem.repository;
using SalesSystem.util;

namespace SalesSystem.view {
    internal class SaleView {
        public static void ShowMenu() {
            SaleRepository repository = SaleRepository.GetInstance();
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
                        Sale? sale = RegisterSale();
                        if(sale != null)
                            repository.Add(sale);
                        break;
                    case "2":
                        SearchSale();
                        break;
                    case "3":
                        ListAll();
                        break;
                    case "4":
                        Report();
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

            Customer? customer = customerRepository.GetByCode(InputUtil.InputInt("Codigo cliente: "));

            if (customer == null) {
                Console.WriteLine("Cliente nao encontrado");
                return null;
            }

            Sale sale = new Sale(customer);

            int code = 1;
            while (code != 0) {
                Console.Clear();

                ProductView.ListAll();

                code = InputUtil.InputInt("Codigo [0 para sair]: ");

                if (code == 0)
                    break;

                Product? product = productRepository.GetByCode(code);

                if (product == null) {
                    Console.WriteLine("Produto nao encontrado!");
                    InterfaceUtil.PressEnterToContinue();
                    continue;
                }

                sale.AddProduct(product);
            }

            if(sale.GetItems().Length == 0) {
                Console.WriteLine("A venda deve possuir no minimo um produto");
                return null;
            }

            Console.WriteLine("\nResumo:\n" + sale);
            return sale;
        }

        public static void SearchSale() {
            SaleRepository repository = SaleRepository.GetInstance();

            int code = InputUtil.InputInt("Codigo: "); ;

            Sale? sale = repository.GetByCode(code);

            if (sale == null) {
                Console.WriteLine("Venda nao encontrada");
                return;
            }

            Console.WriteLine(sale);
        }

        public static void ListAll() {
            foreach (Sale sale in SaleRepository.GetInstance().GetAll())
                Console.WriteLine(sale);
        }

        public static void Report() {
            SaleRepository saleRepository = SaleRepository.GetInstance();
            int saleQtt = 0;
            double saleTotal = 0;

            foreach(Sale sale in saleRepository.GetAll()) {
                saleQtt++;
                saleTotal += sale.GetTotalValue();
            }

            Console.WriteLine("Quantidade de vendas: " + saleQtt);
            Console.WriteLine($"Valor total: R${saleTotal:#.##}");
        }
    }
}
