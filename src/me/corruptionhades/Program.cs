public class Program {

    public static void Main() {
        while(true) {
            Console.WriteLine("Welcome to CorruptionHades' Java Injection Client Helper!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Generate a wrapper");
            Console.WriteLine("2. Generate a hook (Only Yarn mappings supported)");
            Console.WriteLine("3. Search for a class, method or field");
            Console.WriteLine("4. Exit");
            string input = Console.ReadLine();
            if(input == "1") {
                WrapperGenerator.generateWrapper();
            } else if(input == "2") {
                HookGenerator.generateHook();
            } else if(input == "3") {
                Searcher.search();
            } else if(input == "4") {
                Environment.Exit(0);
                break;
            } else {
                Console.WriteLine("Invalid input!");
            }
        }
    }

}