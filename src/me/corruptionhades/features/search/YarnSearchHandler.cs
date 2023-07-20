public class YarnSearchHandler {

    public static void handleSearch(string searchQuery) {
        if(searchQuery.Contains("#")) {
            string[] parts = searchQuery.Split("#");
            string className = parts[0];
            string methodName = parts[1];

            YarnClass yc = findClass(className);

            if(yc == null) {
                Console.WriteLine("Error: Could not find class: " + className);
                return;
            }

            handleMethodSearch(yc, methodName);
        }
        else if(searchQuery.Contains("+")) {
            string[] parts = searchQuery.Split("+");
            string className = parts[0];
            string fieldName = parts[1];

            YarnClass yc = findClass(className);

            if(yc == null) {
                Console.WriteLine("Error: Could not find class: " + className);
                return;
            }
            
            handleFieldSearch(yc, fieldName);
        }
        else {
            YarnClass yc = findClass(searchQuery);

            if(yc == null) {
                Console.WriteLine("Error: Could not find class: " + searchQuery);
                return;
            }

            Console.WriteLine("Found class: " + yc.getName());
            Console.WriteLine("Obfuscated name: " + yc.getOfficial()); 
        }
    }

    private static void handleMethodSearch(YarnClass yc, string methodName) {
        Console.WriteLine("Found class: " + yc.getName());
        Console.WriteLine("Obfuscated name: " + yc.getOfficial()); 

        foreach (YarnMethod method in yc.getMethods()) {
            if(method.getName() == methodName || method.getOfficial() == methodName) {
                Console.WriteLine("Found method: " + method.getName());
                Console.WriteLine("Obfuscated name: " + method.getOfficial());
                Console.WriteLine("Return type: " + method.getReturnType());
                Console.WriteLine("Parameters: ");
                foreach (YarnParam param in method.getParameters()) {
                    Console.WriteLine("    " + param.getType().getName());
                }
                return;
            }
        }
    }

    private static void handleFieldSearch(YarnClass yc, string fieldName) {
        Console.WriteLine("Found class: " + yc.getName());
        Console.WriteLine("Obfuscated name: " + yc.getOfficial()); 

        foreach (YarnField field in yc.getFields()) {
            if(field.getName() == fieldName || field.getOfficial() == fieldName) {
                Console.WriteLine("Found field: " + field.getName());
                Console.WriteLine("Obfuscated name: " + field.getOfficial());
                string returnType = field.getReturnType();
                YarnClass returnTypeClass = findClass(returnType);
                if(returnTypeClass != null) {
                    Console.WriteLine("Type: " + returnTypeClass.getName());
                    return;
                }
                Console.WriteLine("Type: " + returnType);
                return;
            }
        }
    }

    private static YarnClass findClass(string name) {
        return YarnMapper.getByName(name);
    }
}