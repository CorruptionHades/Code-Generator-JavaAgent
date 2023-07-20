public class YarnParam {

    private YarnClass type;
    private String name;

    public YarnParam(YarnClass type) {
        this.type = type;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public YarnClass getType() {
        return type;
    }
    
}