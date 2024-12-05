namespace SalesSystem.util {
    internal class InputUtil {
        public static int InputInt(String text) {
            try {
                Console.Write(text);
                return Convert.ToInt32(Console.ReadLine());
            } catch (Exception) {
                Console.WriteLine("Numero inteiro invalido!");
                return InputInt(text);
            }
        }
        public static double InputDouble(String text) {
            try {
                Console.Write(text);
                return Convert.ToDouble(Console.ReadLine());
            } catch (Exception) {
                Console.WriteLine("Numero real invalido!");
                return InputDouble(text);
            }
        }
    }
}
