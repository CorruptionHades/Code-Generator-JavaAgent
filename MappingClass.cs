public class MappingClass {

 public string Name { get; set; }
    public string ObfuscatedName { get; set; }

    public MappingClass(string name, string obfuscatedName) {
        Methods = new Dictionary<string, string>();
        Fields = new Dictionary<string, string>();
        this.Name = name;
        this.ObfuscatedName = obfuscatedName;
    }
   
    public Dictionary<string, string> Methods { get; set; }
    public Dictionary<string, string> Fields { get; set; }

}