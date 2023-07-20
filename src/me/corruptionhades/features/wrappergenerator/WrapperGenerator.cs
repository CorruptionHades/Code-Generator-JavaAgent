public class WrapperGenerator {
    public static void generateWrapper() {
        Console.WriteLine("Would you like to generate a wrapper from Mojang or Yarn mappings? (M/Y)");
        string input = Console.ReadLine();
        if(input == "M") {
            handleMojangGeneration();
        } else if(input == "Y") {
            handleYarnGeneration();
        } else {
            Console.WriteLine("Invalid input!");
        }
    }

    private static void handleMojangGeneration() {
        Console.WriteLine("Please enter the path to the mappings.txt file: ");
        string filePath = Console.ReadLine();
        Console.WriteLine("Parsing mappings... This may take a while.");
        MojangMapper.mapMojang(filePath);
        Console.WriteLine("Parsing complete!");
        Console.WriteLine();
        while(true) {
            Console.WriteLine();
            Console.WriteLine("Enter class with package to generate or enter EXIT to exit: ");
            string classToMake = Console.ReadLine().Replace(".", "/");

            if(classToMake == "EXIT") {
                break;
            }

            MappingClass search = MojangMapper.getByName(classToMake);
            if(search == null) {
                Console.WriteLine("Error: class " + classToMake + " not found!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Class: " + search.Name + " -> " + search.ObfuscatedName);
            Console.WriteLine("Attempting to generate wrapper...");
            string classCode = MojangClassGenerator.generate(search);

            String[] packageParts = search.Name.Split("/");
            String packagePath = "out/wrappers/";
            for (int i = 0; i < packageParts.Length - 1; i++) {
                packagePath += packageParts[i] + "/";
            }

            // Create the directories
            Directory.CreateDirectory(packagePath);
            File.WriteAllText(packagePath + packageParts[packageParts.Length - 1] + "Wrapper.java", classCode);

            Console.WriteLine("Successfully generated Wrapper class! You can find it in the out folder.");
        }
    }

    private static void handleYarnGeneration() {
        Console.WriteLine("Please enter the path to the mappings.tiny file: ");
        string filePath = Console.ReadLine();
        Console.WriteLine("Parsing mappings... This may take a while.");
        YarnMapper.mapFile(filePath);
        Console.WriteLine("Parsing complete!");
        Console.WriteLine();
        while(true) {
            Console.WriteLine();
            Console.WriteLine("Enter class with package to generate or enter EXIT to exit: ");
            string classToMake = Console.ReadLine().Replace(".", "/");

            if(classToMake == "EXIT") {
                break;
            }

            YarnClass search = YarnMapper.getByName(classToMake);
            if(search == null) {
                Console.WriteLine("Error: class " + classToMake + " not found!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Class: " + search.getName() + " -> " + search.getOfficial());
            Console.WriteLine("Attempting to generate wrapper...");
            string classCode = YarnClassGenerator.generate(search);

            String[] packageParts = search.getName().Split("/");
            String packagePath = "out/wrappers/";
            for (int i = 0; i < packageParts.Length - 1; i++) {
                packagePath += packageParts[i] + "/";
            }

            // Create the directories
            Directory.CreateDirectory(packagePath);
            File.WriteAllText(packagePath + packageParts[packageParts.Length - 1] + "Wrapper.java", classCode);

            Console.WriteLine("Successfully generated Wrapper class! You can find it in the out folder.");
        }
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}