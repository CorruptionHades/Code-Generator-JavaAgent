using System.Text.RegularExpressions;

public class YarnMapper {

    public static List<YarnClass> classList = new List<YarnClass>();
    private static YarnClass? currentClass;

    public static void mapFile(String file) {
        classList.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string fileLine in lines) {
            string line = fileLine;

            if(line.StartsWith("c")) {
                handleClass(line);
            }
            else if(line.StartsWith("	m")) {
                handleMethod(line);
            }
            else if(line.StartsWith("	f")) {
                handleField(line);
            }
        }
    }

    private static void handleClass(string line) {
        String[] split = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
        String official = split[1];
        String name = split[2];

        YarnClass yc = new YarnClass(official, name);
        currentClass = yc;
        classList.Add(yc);
    }

    private static void handleMethod(string line) {
        String[] split = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
        
        String[] paramsAndreturnType = split[1].Split(")");

        String paramstring = paramsAndreturnType[0] + ")";
        String returnType = paramsAndreturnType[1];

        if(returnType.Length == 1) {
            returnType = MapTypeString(returnType);
        }
        else {
            returnType = returnType.Substring(1);
        }

        List<String> parameters = ParseParameterTypes(paramstring);

        String official = split[2];
        String name = split[3];

        YarnMethod method = new YarnMethod(official, name, returnType);

        foreach(String param in parameters) {

            if(param.Equals("")) continue;

            YarnClass yc = getByName(param);
            if(yc == null) {
                yc = new YarnClass(param, param);
            }
            YarnParam yarnParam = new YarnParam(yc);
            
            method.addParameter(yarnParam);
        }
    
        currentClass.Methods.Add(method);
    }

    private static void handleField(string line) {
        String[] split = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
        String returnType = split[1].Substring(1, split[1].Length -1 ).Replace(";", "");
        String official = split[2];
        String name = split[3];
        YarnField field = new YarnField(official, name, returnType);
        currentClass.Fields.Add(field);
    }

    private static String GetBetween(String orig, String s1, String s2) {
        int startIndex = orig.IndexOf(s1);
        int endIndex = orig.IndexOf(s2);
    
        if (startIndex != -1 && endIndex != -1 && startIndex < endIndex) {
            int substringStartIndex = startIndex + s1.Length;
            int substringLength = endIndex - substringStartIndex;
            String extractedString = orig.Substring(substringStartIndex, substringLength);
    
            return extractedString;
        }

        return String.Empty;
    }

    private static String ReplaceExcessiveWhitespaces(string input) {
        string result = Regex.Replace(input, @"\s+", m => {
            if (m.Value.Length > 1) {
                return " ";
            }
            else {
                return m.Value;
            }
        });

        return result;
    }

    public static YarnClass getByName(String name) {
        foreach(YarnClass yc in classList) {
            if(yc.name.Equals(name) || yc.official.Equals(name)) {
                return yc;
            }
        }

        return null;
    }

    private static List<string> ParseParameterTypes(string input) {
        List<string> parameterTypes = new List<string>();

        // Remove the outer parentheses
        string cleanedInput = input.TrimStart('(').TrimEnd(')');

        bool customType = false;
        bool array = false;
        String currentCustomType = "";

        for (int i = 0; i < cleanedInput.Length; i++) {
            char currentChar = cleanedInput[i];

            if(currentChar == '[') {
                array = true;
                continue;
            }
            if (currentChar == 'L') {
                customType = true;
                continue;
            }
            if(currentChar == ';') {
                customType = false;
                parameterTypes.Add(currentCustomType.Replace('/', '.') + (array ? "[]" : ""));
                currentCustomType = "";
                continue;
            }
            if(customType) {
                currentCustomType += currentChar;
            }
            else {
                if(currentChar == 'L') continue;
                String type = MapTypeString(currentChar.ToString());
                parameterTypes.Add(type + (array ? "[]" : ""));
            }
            
        }

        return parameterTypes;
    }

    private static string MapTypeString(string typeString) {
        switch (typeString) {
            case "B": return "byte";
            case "C": return "char";
            case "D": return "double";
            case "F": return "float";
            case "I": return "int";
            case "J": return "long";
            case "S": return "short";
            case "Z": return "boolean";
            case "V": return "void";
            default:
                return "-1";
        }
    } 
}