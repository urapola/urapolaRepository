namespace ConsoleAppRobot

{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();
                GetInputString(input);
            }
        }

        private static string GetInputString(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            Command cmd = new();
            var result = Command.Execute(input.ToUpper());

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
            return result;
        }
    }
}