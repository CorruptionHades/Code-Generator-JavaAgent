public class YarnMain {

    public static void example(string[] args) {
        Console.WriteLine("Mapping yarn...");
        YarnMapper.mapFile(@"mappings\mappings.tiny");
        Console.WriteLine("Mapping yarn done!");
        //YarnMapper.mapYarn(@"mappings\yarn.tiny");

        YarnClass search = YarnMapper.getByName("enn");
        Console.WriteLine(search.name + ": " + search.official);
        foreach (YarnMethod method in search.Methods) {
            Console.WriteLine(method.getName() + ": " + method.getOfficial() + "; " + method.getReturnType());
        }
        foreach (YarnField field in search.Fields) {
            Console.WriteLine(field.getName() + ": " + field.getOfficial() + "; " + field.getReturnType());
        }
    
    }
    
}