public class ClassGenerator {

    public static string generate(MappingClass mappingClass) {

        // Only get the class name without package
        string className = mappingClass.Name.Split(".")[mappingClass.Name.Split(".").Length - 1];

        string classCode =
         "import corruptionhades.injection.misc.Classes; \n" + 
         "import corruptionhades.utils.ReflectionHelper; \n" +
         "import corruptionhades.injection.OOPWrapper; \n \n" + 
         "import java.lang.reflect.*; \n" + "\n" +
         "public class " + className + " extends OOPWrapper { \n \n" +
         "    public " + className + "(Object instance) { \n" +
         "        super(ReflectionHelper.getClass(\"" + mappingClass.ObfuscatedName + "\"), instance); \n" +
         "    } \n \n";

        foreach(var field in mappingClass.Fields) {
            string unobfuscatedName = field.Key;
            string obfuscatedName = field.Value.Split(":")[0];
            string type = field.Value.Split(":")[1];

            classCode += generateFields(unobfuscatedName, obfuscatedName, type);
        }

        foreach(var method in mappingClass.Methods) {
            string unobfuscatedName = method.Key;
            string obfuscatedName = method.Value.Split(":")[0];
            string returnType = method.Value.Split(":")[1];

            if(unobfuscatedName.Contains("init")) continue;

            string doc = generateDoc(unobfuscatedName, returnType);
            string methodCode = generateMethodCode(unobfuscatedName, obfuscatedName, returnType);
            classCode += doc + methodCode;

        }
        classCode += "} \n";
        return classCode;
    }

    private static string generateMethodCode(string unobfuscatedName, string obfuscatedName, string returnType) {

        string between = unobfuscatedName.Substring(unobfuscatedName.IndexOf("(") + 1, unobfuscatedName.IndexOf(")") - unobfuscatedName.IndexOf("(") - 1);
        string[] args = between.Split(",");

        if(!checkReturnType(returnType)) {
            returnType = "Object";
        }

        string types = ", ";
        string invokeArgs = ", ";

        int count = 0;
        foreach(string arg in args) {

            if(checkReturnType(arg)) {

                if(count == args.Length - 1) { 
                        types += arg + ".class";
                    }
                    else types += arg + ".class, ";

                if(count == args.Length - 1) {
                    invokeArgs += "a" + count;
                }
                else invokeArgs += "a" + count + ", ";
            }
            else {
                MappingClass mappingClass = Program.getByName(arg.Trim());
                if(mappingClass != null) {
                    if(count == args.Length - 1) {
                        types += "ReflectionHelper.getClass(\"" + mappingClass.ObfuscatedName + "\")";
                    }
                    else types += "ReflectionHelper.getClass(\"" + mappingClass.ObfuscatedName + "\"), ";

                    if(count == args.Length - 1) {
                        invokeArgs += "a" + count;
                    }
                    else invokeArgs += "a" + count + ", ";
                }
                else {
                    if(count == args.Length - 1) {
                        types += arg + ".class";
                    }
                    else types += arg + ".class, ";

                if(count == args.Length - 1) {
                    invokeArgs += "a" + count;
                }
                else invokeArgs += "a" + count + ", ";
                }
            }

            count++;
        }

        if(between == "") {
            types = "";
            invokeArgs = "";
        }

        string methodLine = 
            "    public " + returnType + " " + checkMethodName(unobfuscatedName) + " throws Exception { \n" +
            "        Method method = clazz.getMethod(\"" + obfuscatedName + "\"" + types + "); \n" +
            (returnType.Equals("void") ? "        rh.invoke(method, instance" + invokeArgs + "); \n" : "        return " + (returnType.Equals("Object") ? "" : "(" + returnType + ") ") + "rh.invokeReturn(method, instance" + invokeArgs + "); \n") +
            "    } \n";
            ;

        return methodLine;
    }

    private static string generateDoc(string method, string returnType) {

        string between = method.Substring(method.IndexOf("(") + 1, method.IndexOf(")") - method.IndexOf("(") - 1);
        string[] methodArgs = between.Split(",");
        string[] origMethodArgs = method.Substring(method.IndexOf("(") + 1, method.IndexOf(")") - method.IndexOf("(") - 1).Split(",");

        if(!checkReturnType(returnType)) {
            returnType = "Object";
        }
        
        int count = 0;
        foreach(string arg in methodArgs) {
            
            // check if arg is empty
            if(arg.Trim().Equals("")) continue;

            if(!checkReturnType(arg)) {
                methodArgs[count] = "Object a" + count;
            }
            else {
                methodArgs[count] = arg + " a" + count;
            }

            count++;
        }

        string docs = "\n    /** \n";
        count = 0;
        foreach(string arg in methodArgs) {
            if(arg.Trim().Equals("")) continue;

            string argName = arg.Split(" ")[1];

            if(arg.Contains("Object")) {
                docs += "     * @param " + argName + " " + origMethodArgs[count] + "\n";
            }
            else docs += "     * @param " + argName + "\n";
            count++;
        }

        if(!returnType.Equals("void")) {
                docs += "     * @return " + returnType + "\n";
        }
        docs += "    **/ \n";

        if(between == "" && returnType.Equals("void")) {
            docs = "\n";
        }

        return docs;
    }

    private static string checkMethodName(string method) {
        string[] methodArgs = method.Substring(method.IndexOf("(") + 1, method.IndexOf(")") - method.IndexOf("(") - 1).Split(",");
        int count = 0;
        foreach(string arg in methodArgs) {

            // check if arg is empty
            if(arg.Trim().Equals("")) continue;

            if(!checkReturnType(arg)) {
                methodArgs[count] = (count == 0 ? "" : " ") + "Object a" + count;
            }
            else {
                methodArgs[count] = (count == 0 ? "" : " ") + arg + " a" + count;
            }

            count++;
        }
        count = 0;

        string methodName = method.Substring(0, method.IndexOf("("));
        methodName += "(";
        foreach(string arg in methodArgs) {
            if(arg.Trim().Equals("")) continue;

            methodName += arg;
            if(!arg.Equals(methodArgs[methodArgs.Length - 1])) {
                methodName += ",";
            }
        }
        methodName += ")";

        return methodName;
    }

    private static string generateFields(string unobfuscatedName, string obfuscatedName, string type) {

        if(!checkReturnType(type)) {
            type = "Object";
        }

        string getter = 
        "    public " + type + " " + unobfuscatedName + "() throws Exception { \n" + 
        "        return " + (type.Equals("Object") ? "" : "(" + type + ") ") + "rh.getField(\"" + obfuscatedName + "\", instance); \n" +
        "    }\n";

        string param = unobfuscatedName.ToLower();
        string setter = "\n" +
        "    public " + type + " " + unobfuscatedName + "(" + type + " " + param + ") throws Exception { \n" + 
        "        rh.setField(\"" + obfuscatedName + "\", instance, " + param + "); \n" +
        "        return " + param + "; \n" +
        "    } \n \n";

        return getter + setter;
    }

    private static Boolean checkReturnType(string type) {
        if(
            type.Equals("int")
            || type.Equals("float")
            || type.Equals("double")
            || type.Equals("long")
            || type.Equals("short")
            || type.Equals("byte")
            || type.Equals("boolean")
            || type.Equals("char")
            || type.Equals("void")
            || type.Equals("java.lang.String[]")
            || type.Equals("int[]")
            || type.Equals("float[]")
            || type.Equals("double[]")
            || type.Equals("long[]")
            || type.Equals("short[]")
            || type.Equals("byte[]")
            || type.Equals("boolean[]")
            || type.Equals("char[]")
            || type.Equals("java.util.List")
            || type.Equals("java.lang.String")
            || type.Contains("java.lang.")
            ) return true;
        return false;
    }
}