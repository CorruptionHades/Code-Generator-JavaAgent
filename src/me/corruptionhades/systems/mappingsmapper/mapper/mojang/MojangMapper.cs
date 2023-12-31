
public class MojangMapper {

    public static List<MappingClass> classList = new List<MappingClass>();
    public static void mapMojang(String file) {
        classList.Clear();
        string[] lines = File.ReadAllLines(file);

        MappingClass currentClass = null;

        foreach (string fileLine in lines) {
            string line = fileLine.Replace("    ", "");
            if (line.EndsWith(":")) {
                string[] classParts = line.Split(" -> ");

                string unobfuscatedName = classParts[0].Trim().Replace(" ", "_");
                string obfuscatedName = classParts[1].Trim().Replace(":", "").Replace(" ", "");

                MappingClass mappingClass = new MappingClass(unobfuscatedName, obfuscatedName);
                currentClass = mappingClass;
                classList.Add(mappingClass);
            }
            else if (line.Contains("->")) {
                // Method
                if(line.Contains(":") || line.Contains("()")) {
                    string[] methodParts = line.Split(" -> ");
                    string obfuscatedName = methodParts[1].Trim();

                    string[] methodParts2 = line.Split(" ");
                    string methodName = methodParts2[1].Trim();
                    string types = methodParts2[0].Trim();

                    if(currentClass == null) {
                        Console.WriteLine("Error: currentClass is null!");
                        return;
                    }

                    if(currentClass.Methods == null) {
                        Console.WriteLine("Error: currentClass.Methods is null!");
                        return;
                    }

                    if(line.Contains(":")) {
                        string[] types2 = types.Split(":");
                        string returnType = types2[2].Trim();

                        if(!currentClass.Methods.ContainsKey(methodName)) {
                            currentClass.Methods[methodName] = obfuscatedName + ":" + returnType;
                        }
                    }
                    else {
                        if(!currentClass.Methods.ContainsKey(methodName)) {
                            currentClass.Methods[methodName] = obfuscatedName + ":void";
                        }
                    }
                  
                }
                // Field
                else {
                    string[] fieldParts = line.Split(" -> ");
                    string obfuscatedName = fieldParts[1].Trim();

                    string[] fieldParts2 = line.Split(" ");
                    string fieldName = fieldParts2[1].Trim();
                    string types = fieldParts2[0].Trim();
                    string fieldType = types.Trim();

                    if (currentClass == null)  {
                        Console.WriteLine("Error: currentClass is null!");
                        return;
                    }

                    if (currentClass.Fields == null) {
                        Console.WriteLine("Error: currentClass.Fields is null!");
                        return;
                    }

                    if (!currentClass.Fields.ContainsKey(fieldName)) {
                        currentClass.Fields[fieldName] = obfuscatedName + ":" + fieldType;
                    }
                }  
            }
        }

        Console.WriteLine("Mapped " + classList.Count + " classes!");
    }

    public static MappingClass getByName(string name) {
        name = name.Replace("[", "").Replace("]", "");
        foreach (MappingClass mappingClass in classList) {
            if (mappingClass.Name == name || mappingClass.ObfuscatedName == name) {
                return mappingClass;
            }
        }

        return null;
    }
}