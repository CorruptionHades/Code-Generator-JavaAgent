public class YarnMethod {

    private String name, official, returnType;
    private List<YarnParam> parameters;

    public YarnMethod(String official, String name, String returnType) {
        this.name = name;
        this.official = official;
        this.returnType = returnType;
        parameters = new List<YarnParam>();
    }

    public String getName() {
        return name.Replace("/", ".");
    }

    // TODO: Maybe unsafe replacing
    public String getReturnType() {
        return returnType.Replace("/", ".").Replace(";", "");
    }

    public String getOfficial() {
        return official.Replace("/", ".");
    }

    public List<YarnParam> getParameters() {
        return parameters;
    }

    public void addParameter(YarnParam param) {
        parameters.Add(param);
    }
    
}