public class YarnClassGenerator {

    public static String generate(YarnClass yc) {
        string className = yc.getName().Split("/")[yc.getName().Split("/").Length - 1];

        string classCode =
         "import corruptionhades.injection.misc.Classes; \n" + 
         "import corruptionhades.utils.ReflectionHelper; \n" +
         "import corruptionhades.injection.OOPWrapper; \n \n" + 
         "import java.lang.reflect.*; \n" + "\n" +
         " /* \n" +
        " * Auto generated Wrapper class \n" +
        " * using CorruptionHades' Wrapper generator \n" +
        " * @author CorruptionHades \n" + 
        " */ \n \n" +
         "public class " + className + "Wrapper extends OOPWrapper { \n \n" +
         "    public " + className + "(Object instance) { \n" +
         "        super(ReflectionHelper.getClass(\"" +  yc.getOfficial() + "\"), instance); \n" +
         "    } \n \n";

         foreach(YarnField field in yc.Fields) {
             string unobfuscatedName = field.getName();
             string obfuscatedName = field.getOfficial();
             string type = field.getReturnType();

             classCode += generateFields(unobfuscatedName, obfuscatedName, type);
         }

         foreach(YarnMethod method in yc.Methods) {
            string unobfuscatedName = method.getName();
            if(unobfuscatedName.Contains("init")) continue;

            string doc = generateDoc(method);
            string methodCode = generateMethodCode(method);
            classCode += doc + methodCode;

        }
        classCode += "} \n";
        return classCode;
    }

    private static string generateMethodCode(YarnMethod method) {

        string unobfuscatedName = method.getName();
        string obfuscatedName = method.getOfficial();
        string returnType = method.getReturnType();
        List<YarnParam> parameters = method.getParameters();

        if(!checkReturnType(returnType)) {
            returnType = "Object";
        }

        string types = ", ";
        string invokeArgs = ", ";

        int count = 0;
        foreach(YarnParam param in parameters) {
            string arg = param.getType().getOfficial();
            if(checkReturnType(arg)) {

                if(count == parameters.Count - 1) { 
                        types += arg + ".class";
                    }
                    else types += arg + ".class, ";

                if(count == parameters.Count - 1) {
                    invokeArgs += "a" + count;
                }
                else invokeArgs += "a" + count + ", ";
            }
            else {
                YarnClass yc = param.getType();
                if(yc != null) {
                    if(count == parameters.Count - 1) {
                        types += "ReflectionHelper.getClass(\"" + yc.getOfficial() + "\")";
                    }
                    else types += "ReflectionHelper.getClass(\"" + yc.getOfficial() + "\"), ";

                    if(count == parameters.Count - 1) {
                        invokeArgs += "a" + count;
                    }
                    else invokeArgs += "a" + count + ", ";
                }
                else {
                    if(count == parameters.Count - 1) {
                        types += arg + ".class";
                    }
                    else types += arg + ".class, ";

                if(count == parameters.Count - 1) {
                    invokeArgs += "a" + count;
                }
                else invokeArgs += "a" + count + ", ";
                }
            }

            count++;
        }

        if(parameters.Count == 0) {
            types = "";
            invokeArgs = "";
        }

        string methodLine = 
            "    public " + returnType + " " + createMethodString(method) + " throws Exception { \n" +
            "        Method method = clazz.getMethod(\"" + obfuscatedName + "\"" + types + "); \n" +
            (returnType.Equals("void") ? "        rh.invoke(method, instance" + invokeArgs + "); \n" : "        return " + (returnType.Equals("Object") ? "" : "(" + returnType + ") ") + "rh.invokeReturn(method, instance" + invokeArgs + "); \n") +
            "    } \n";
            ;

        return methodLine;
    }

    private static string generateDoc(YarnMethod method) {

        string unobfuscatedName = method.getName();
        string obfuscatedName = method.getOfficial();
        string returnType = method.getReturnType();
        List<YarnParam> parameters = method.getParameters();

        string docs = "\n    /** \n";

        int count = 0;
        foreach(YarnParam param in method.getParameters()) {
            string type = param.getType().getOfficial();
            if(checkReturnType(type)) {
                docs += "     *" + " a" + count + "\n";
            }
            else {
                docs += "     *" + " a" + count + " " + param.getType().getName() + "\n";
            }
            count++;
        }

        YarnClass yc = YarnMapper.getByName(returnType);

        if(yc != null) {
            returnType = yc.getName().Replace("/", ".");
        }

        if(!returnType.Equals("void")) docs += "     * @return " + returnType + "\n";

        docs += "     */ \n";

        return docs;
    }

    private static string createMethodString(YarnMethod method) {

        string methodString = method.getName() + "(";
        int count = 0;
        foreach(YarnParam param in method.getParameters()) {
            string type = param.getType().getOfficial();
            if(checkReturnType(type)) {
                methodString += type + " a" + count;
            }
            else {
                methodString += "Object a" + count;
            }
            if(count != method.getParameters().Count - 1) {
                methodString += ", ";
            }
            count++;
        }

        methodString += ")";
        return methodString;
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
            || type.Equals("int[]")
            || type.Equals("float[]")
            || type.Equals("double[]")
            || type.Equals("long[]")
            || type.Equals("short[]")
            || type.Equals("byte[]")
            || type.Equals("boolean[]")
            || type.Equals("char[]")
            || type.StartsWith("java.")
            ) return true;
        return false;
    }

}