﻿using SalesSystem.model;
using SalesSystem.repository;

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

                if (!input.Equals("5")) {
                    Console.WriteLine("\nPressione Enter para continuar....");
                    Console.ReadLine();
                }

                Console.Clear();
            }
        }

        private static Customer RegisterCustomer() {
            Console.Write("Nome: ");
            String name = Console.ReadLine() ?? "";

            Console.Write("Idade: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("CPF: ");
            String cpf = Console.ReadLine() ?? "";

            return new Customer(name, age, cpf);
        }

        private static void SearchCustomer() {
            CustomerRepository repository = CustomerRepository.GetInstance();

            Console.Write("Codigo: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Customer? customer = repository.GetByCode(code);

            if (customer == null) {
                Console.WriteLine("Cliente nao encontrado");
                return;
            }

            Console.WriteLine(customer);
        }

        private static void ListAll() {
            foreach (Customer customer in CustomerRepository.GetInstance().GetAll())
                Console.WriteLine(customer);
        }

        private static void RemoveCustomer() {
            CustomerRepository customerRepository = CustomerRepository.GetInstance();
            SaleRepository saleRepository = SaleRepository.GetInstance();

            Console.Write("Codigo: ");
            int code = Convert.ToInt32(Console.ReadLine());

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