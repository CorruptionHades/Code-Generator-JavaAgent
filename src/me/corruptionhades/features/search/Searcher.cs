public class Searcher {

    public static void search() {
        Console.WriteLine("Would you like to search from Mojang or Yarn mappings? (M/Y)");
        string input = Console.ReadLine();
        if(input == "M") {
            handleMojangSearch();
        } else if(input == "Y") {
            handleYarnSearch();
        } else {
            Console.WriteLine("Invalid input!");
        }
    }

    private static void handleMojangSearch() {
        Console.WriteLine("Please enter the path to the mappings.txt file: ");
        string filePath = Console.ReadLine();
        Console.WriteLine("Parsing mappings... This may take a while.");
        MojangMapper.mapMojang(filePath);
        Console.WriteLine("Parsing complete!");
        Console.WriteLine();
        while(true) {
            Console.WriteLine();
            Console.WriteLine("You can enter either the obfuscated or deobfuscated name of the class, method or field. Or enter EXIT to exit.");
            Console.WriteLine("Usage for classes: package.Class");
            Console.WriteLine("Usage for methods: package.Class#method");
            Console.WriteLine("Usage for fields: package.Class+field");
            Console.WriteLine("Enter search query: ");
            string searchQuery = Console.ReadLine();

            if(searchQuery == "EXIT") {
                break;
            }

            MojangSearchHandler.handleSearch(searchQuery);
        }
    }

    private static void handleYarnSearch() {
        Console.WriteLine("Please enter the path to the mappings.tiny file: ");
        string filePath = Console.ReadLine();
        Console.WriteLine("Parsing mappings... This may take a while.");
        YarnMapper.mapFile(filePath);
        Console.WriteLine("Parsing complete!");
        Console.WriteLine();
        while(true) {
            Console.WriteLine();
            Console.WriteLine("You can enter either the obfuscated or deobfuscated name of the class, method or field. Or enter EXIT to exit.");
            Console.WriteLine("Usage for classes: package.Class");
            Console.WriteLine("Usage for methods: package.Class#method");
            Console.WriteLine("Usage for fields: package.Class+field");
            Console.WriteLine("Enter search query: ");
            string searchQuery = Console.ReadLine();

            if(searchQuery == "EXIT") {
                break;
            }

            YarnSearchHandler.handleSearch(searchQuery);
        }
    }
}