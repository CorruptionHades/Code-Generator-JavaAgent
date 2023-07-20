public class MojangSearchHandler {

    public static void handleSearch(string searchQuery) {
    
        if(searchQuery.Contains("#")) {
            string[] parts = searchQuery.Split("#");
            string className = parts[0];
            string methodName = parts[1];

            MappingClass mc = findMappingClass(className);

            if(mc == null) {
                Console.WriteLine("Error: Could not find class: " + className);
                return;
            }

            handleMethodSearch(mc, methodName);
        }
        else if(searchQuery.Contains("+")) {
            string[] parts = searchQuery.Split("+");
            string className = parts[0];
            string fieldName = parts[1];

            MappingClass mc = findMappingClass(className);

            if(mc == null) {
                Console.WriteLine("Error: Could not find class: " + className);
                return;
            }
            
            handleFieldSearching(mc, fieldName);
        }
        else {
            MappingClass mc = findMappingClass(searchQuery);

            if(mc == null) {
                Console.WriteLine("Error: Could not find class: " + searchQuery);
                return;
            }

            Console.WriteLine("Found class: " + mc.Name);
            Console.WriteLine("Obfuscated name: " + mc.ObfuscatedName); 
        }
    }

    private static MappingClass findMappingClass(string name) {
        foreach (MappingClass mappingClass in MojangMapper.classList) {
            if (mappingClass.Name == name) {
                return mappingClass;
            }
            else if (mappingClass.ObfuscatedName == name) {
                return mappingClass;
            }
        }

        return null;
    }

    private static void handleMethodSearch(MappingClass mc, string methodName) {
        Console.WriteLine("Found class: " + mc.Name);
        Console.WriteLine("Obfuscated name: " + mc.ObfuscatedName);
        bool found = false;

        foreach(var method in mc.Methods) {
            string unobfuscatedName = method.Key;
            string obfuscatedName = method.Value.Split(":")[0];
            string returnType = method.Value.Split(":")[1];

            if(unobfuscatedName == methodName || obfuscatedName == methodName) {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Found method: " + unobfuscatedName);
                Console.WriteLine("Obfuscated name: " + obfuscatedName);
                Console.WriteLine("Return type: " + returnType);
                Console.WriteLine("------------------------------");
                found = true;
            } 
        }   

        if(!found) Console.WriteLine("Error: Could not find method: " + methodName);
    }

    private static void handleFieldSearching(MappingClass mc, string fieldName) {
        Console.WriteLine("Found class: " + mc.Name);
        Console.WriteLine("Obfuscated name: " + mc.ObfuscatedName);

        bool found = false;

        foreach(var field in mc.Fields) {
            string unobfuscatedName = field.Key;
            string obfuscatedName = field.Value.Split(":")[0];
            string fieldType = field.Value.Split(":")[1];

            if(unobfuscatedName == fieldName || obfuscatedName == fieldName) {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Found Field: " + unobfuscatedName);
                Console.WriteLine("Obfuscated name: " + obfuscatedName);
                Console.WriteLine("Field type: " + fieldType);
                Console.WriteLine("------------------------------");
                found = true;
            }
        }   

        if(!found) Console.WriteLine("Error: Could not find field: " + fieldName);
    }
}