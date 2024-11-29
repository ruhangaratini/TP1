using SalesSystem.util;
using SalesSystem.view;

internal class Program {
    private static void Main(string[] args) {
        String input = "";

        while(input != "4") {
            Console.WriteLine("------- MENU -------");
            Console.WriteLine("1. Produtos");
            Console.WriteLine("2. Clientes");
            Console.WriteLine("3. Vendas");
            Console.WriteLine("4. Sair");
            Console.WriteLine("------------------------");
            Console.Write("Opcao: ");

            input = Console.ReadLine() ?? "";
            Console.Clear();

            switch (input) {
                case "1":
                    ProductView.ShowMenu();
                    break;
                case "2":
                    CustomerView.ShowMenu();
                    break;
                case "3":
                    SaleView.ShowMenu();
                    break;
            }

            if (!input.Equals("4"))
                InterfaceUtil.PressEnterToContinue();

            Console.Clear();
        }

    }
}