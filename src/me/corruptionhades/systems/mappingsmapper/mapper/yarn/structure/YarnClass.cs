public class YarnClass {

    public String name, official;

    public YarnClass(string official, string name) {
        Methods = new List<YarnMethod>();
        Fields = new List<YarnField>();
        this.name = name;
        this.official = official;
    }
   
    public List<YarnMethod> Methods;
    public List<YarnField> Fields;

    public String getName() {
        return name;
    }

    public String getOfficial() {
        return official.Replace("/", ".");
    }

    public List<YarnMethod> getMethods() {
        return Methods;
    }

    public List<YarnField> getFields() {
        return Fields;
    }

    public YarnMethod getMethodByName(String name) {
        foreach(YarnMethod method in Methods) {
            if(method.getName().Equals(name)) {
                return method;
            }
        }
        return null;
    }

    public YarnMethod getMethodByNameAndParamCount(String name, int paramCount) {
        foreach(YarnMethod method in Methods) {
            if(method.getName().Equals(name) && method.getParameters().Count == paramCount) {
                return method;
            }
        }
        return null;
    }

}