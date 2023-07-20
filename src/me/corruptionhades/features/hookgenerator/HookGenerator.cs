public class HookGenerator {

    public static void generateHook() {
        Console.WriteLine("Would you like to generate a hook from Mojang or Yarn mappings? (M/Y)");
        string input = Console.ReadLine().ToUpper();
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
            Console.WriteLine("Please enter the method you would like to hook. Keep a preset like this package.Class#methodname:amountofparams. Enter EXIT to exit.");
            String input = Console.ReadLine();

            if(input == "EXIT") {
                break;
            }

            String[] parts = input.Split("#");
            String className = parts[0].Replace(".", "/");
            String methodName = parts[1].Split(":")[0];
            int paramCount = int.Parse(parts[1].Split(":")[1]);
            YarnClass yc = YarnMapper.getByName(className);
            if(yc == null) {
                Console.WriteLine("Class not found!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            YarnMethod ym = yc.getMethodByNameAndParamCount(methodName, paramCount);    
            if(ym == null) {
                Console.WriteLine("Method not found!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Please enter the location of the hook. (BEFORE, AFTER)");
            String location = Console.ReadLine().ToUpper();
            if(location == "BEFORE" || location == "B") {
                location = "BEFORE";
            } else if(location == "AFTER" || location == "A") {
                location = "AFTER";
            } else {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Generating hook...");
            String code = YarnHookGenerator.generateHook(yc, ym, location);
            
            // Create the directories
            String packagePath = "out/hooks/";
            Directory.CreateDirectory(packagePath);
            File.WriteAllText(packagePath + yc.getName().Split("/")[yc.getName().Split("/").Length - 1] + "Hook.java", code);
            Console.WriteLine("Hook generated!");
        }
    }
    
}