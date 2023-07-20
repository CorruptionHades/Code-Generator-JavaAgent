public class YarnHookGenerator {
    public static String generateHook(YarnClass yc, YarnMethod ym, String location) {

        String name = yc.getName().Split("/")[yc.getName().Split("/").Length - 1];

        String code = 
        "import corruptionhades.hook.Hook; \n" +
        "import corruptionhades.utils.CodeInjection; \n \n" +
        "public class " + name + "Hook { \n \n" +
        "    public " + name + "Hook { \n" +
        "        super(ReflectionHelper.getClass(\"" + yc.getOfficial() + "\")); \n" + 
        "    } \n \n" +
        ""
        ;

        String paramaterString = "\"";
        List<YarnParam> parameters = ym.getParameters();
        foreach(YarnParam param in parameters) {
            if(parameters.IndexOf(param) == parameters.Count - 1) {
                paramaterString += param.getType().getOfficial() + "\"";
                continue;
            }
            paramaterString += param.getType().getOfficial() + "\", \"";
        }

        String methodCode =
         "    @IMethodHook(methodName = \"" + ym.getOfficial() + "\", location = CodeInjection.Location." + location + ", methodParams = {" + paramaterString + "})" + "\n" +
         "    public String " + ym.getName() + "Hook() { \n" + 
         "        return \"{ /* Code here */ }\"; \n" +
         "    }";

         code += methodCode + "\n \n" + "}";

        return code;
    }
}