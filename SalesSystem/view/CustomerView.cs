using SalesSystem.model;
using SalesSystem.repository;
using SalesSystem.util;

namespace SalesSystem.view {
    internal class CustomerView {
        public static void ShowMenu() {
            CustomerRepository repository = CustomerRepository.GetInstance();
            String input = "";

            while (!input.Equals("5")) {
                Console.WriteLine("------- CLIENTES -------");
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
                        repository.Add(RegisterCustomer());
                        break;
                    case "2":
                        SearchCustomer();
                        break;
                    case "3":
                        ListAll();
                        break;
                    case "4":
                        RemoveCustomer();
                        break;
                }

                if (!input.Equals("5"))
                    InterfaceUtil.PressEnterToContinue();

                Console.Clear();
            }
        }

        public static Customer RegisterCustomer() {
            Console.Write("Nome: ");
            String name = Console.ReadLine() ?? "";

            int age = InputUtil.InputInt("Idade: ");

            Console.Write("CPF: ");
            String cpf = Console.ReadLine() ?? "";

            return new Customer(name, age, cpf);
        }

        public static void SearchCustomer() {
            CustomerRepository repository = CustomerRepository.GetInstance();

            int code = InputUtil.InputInt("Codigo: ");

            Customer? customer = repository.GetByCode(code);

            if (customer == null) {
                Console.WriteLine("Cliente nao encontrado");
                return;
            }

            Console.WriteLine(customer);
        }

        public static void ListAll() {
            foreach (Customer customer in CustomerRepository.GetInstance().GetAll())
                Console.WriteLine(customer);
        }

        public static void RemoveCustomer() {
            CustomerRepository customerRepository = CustomerRepository.GetInstance();
            SaleRepository saleRepository = SaleRepository.GetInstance();

            int code = InputUtil.InputInt("Codigo: ");

            Customer? customer = customerRepository.GetByCode(code);

            if (customer == null) {
                Console.WriteLine("Cliente nao encontrado");
                return;
            }

            if(saleRepository.CustomerHasSale(customer)) {
                Console.WriteLine("O cliente ja realizou uma compra");
                return;
            }

            customerRepository.Remove(customer);
            Console.WriteLine("Cliente removido com sucesso");
        }
    }
}
